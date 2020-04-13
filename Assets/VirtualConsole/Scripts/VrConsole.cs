using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Technie.VirtualConsole
{
	public class VrConsole : MonoBehaviour
	{
		// Structures

		struct LogMessage
		{
			public string text;
			public string stackTrace;
			public LogType type;
			public int sequenceNumber;

			public LogMessage(string t, string trace, LogType type, int seqNum)
			{
				this.text = t;
				this.stackTrace = trace;
				this.type = type;
				this.sequenceNumber = seqNum;
			}
		}

		struct LogLine
		{
			public string text;
			public Color colour;

			public LogLine(string s, Color c)
			{
				this.text = s;
				this.colour = c;
			}
		}

		// Constants

		static readonly Dictionary<LogType, Color> logTypeColors = new Dictionary<LogType, Color>()
		{
			{ LogType.Assert, Color.white },
			{ LogType.Error, Color.red },
			{ LogType.Exception, Color.red },
			{ LogType.Log, Color.white },
			{ LogType.Warning, Color.yellow },
		};

		// Public Properties

		public Text[] consoleLines;

		public Button infoToggleButton;
		public Button warningToggleButton;
		public Button errorToggleButton;

		public Text infoButtonText;
		public Text warningButtonText;
		public Text errorButtonText;

		// Internal State

		private System.Object mutex = new System.Object ();

		private List<LogMessage> infoMessages = new List<LogMessage>();
		private List<LogMessage> warningMessages = new List<LogMessage>();
		private List<LogMessage> errorMessages = new List<LogMessage>();

		private int numInfos;
		private int numWarnings;
		private int numErrors;

		private int nextSequenceNumber;

		private bool hasMessagesChanged;

		private bool showInfo = true;
		private bool showWarnings = true;
		private bool showErrors = true;

		void OnEnable ()
		{
			Application.logMessageReceivedThreaded += HandleLog;
		}
		
		void OnDisable ()
		{
			Application.logMessageReceivedThreaded -= HandleLog;
		}

		void Start()
		{
			UpdateLogVisual ();
			UpdateButtonColours ();
		}

		void Update()
		{
			if (hasMessagesChanged)
			{
				UpdateLogVisual();
			}
		}

		void HandleLog (string text, string stackTrace, LogType type)
		{
			lock (mutex)
			{
				LogMessage newLog = new LogMessage (text, stackTrace, type, nextSequenceNumber++);

				List<LogMessage> list = FindList(type);
				list.Add(newLog);

				// Trim this list down so we don't save more history than we need to
				while (list.Count >= consoleLines.Length)
					list.RemoveAt (0);

				IncLogCount(type);

				hasMessagesChanged = true;
			}
		}

		private void UpdateLogVisual()
		{
			lock(mutex)
			{
				List<LogMessage> displayedMessages = new List<LogMessage>();

				// Gather all messages to display

				if (showInfo)
				{
					foreach (LogMessage msg in infoMessages)
					{
						displayedMessages.Add(msg);
					}
				}

				if (showWarnings)
				{
					foreach (LogMessage msg in warningMessages)
					{
						displayedMessages.Add(msg);
					}
				}

				if (showErrors)
				{
					foreach (LogMessage msg in errorMessages)
					{
						displayedMessages.Add(msg);
					}
				}

				// Sort the merged list
				displayedMessages.Sort(SequenceComparator);

				// Trim the list down to size (so we don't expand more entries than we need to
				while(displayedMessages.Count > consoleLines.Length)
					displayedMessages.RemoveAt(0);

				// Now expand into the individual coloured lines
				List<LogLine> lines = new List<LogLine>();

				for (int i=0; i<displayedMessages.Count; i++)
				{
					LogMessage msg = displayedMessages[i];

					// Only show the first line of the message
					string txt = msg.text;
					txt = txt.Split('\n')[0];

					lines.Add(new LogLine(txt, logTypeColors[msg.type]));

					if (msg.type != LogType.Log)
					{
						// Also display the second line of the stack trace

						string[] trace = msg.stackTrace.Split('\n');
						if (trace.Length >= 2)
						{
							// Reformat the trace line so it's more compact and readable

							string namespaceName, className, methodName, fileName;
							int lineNum;
							if (ParseTrace(trace[1], out namespaceName, out className, out methodName, out fileName, out lineNum))
							{
								string traceText = " > " + fileName + ":" + lineNum + " " + methodName;

								Color colour = logTypeColors[msg.type];
								colour.r *= 0.8f;
								colour.g *= 0.8f;
								colour.b *= 0.8f;

								lines.Add(new LogLine(traceText, colour));
							}
						}
					}
				}

				// Trim the lines down to final size
				while(lines.Count > consoleLines.Length)
					lines.RemoveAt(0);

				// Now actually display the lines on the ui components

				for (int i=0; i<consoleLines.Length; i++)
				{
					Text textVisual = consoleLines[i];

					if (i < lines.Count)
					{
						LogLine line = lines[i];

						// Truncate text if nessesary
						int maxChars = 40;
						string txt = line.text;
						if (txt.Length > maxChars)
						{
							txt = txt.Substring(0, maxChars) + "...";
						}

						textVisual.text = txt;
						textVisual.color = line.colour;
					}
					else
					{
						textVisual.text = "";
					}
				}

				UpdateButtonColours ();

				hasMessagesChanged = false;
			}
		}

		private List<LogMessage> FindList(LogType type)
		{
			switch (type)
			{
				case LogType.Log:
					return infoMessages;
				case LogType.Warning:
					return warningMessages;
				case LogType.Error:
				case LogType.Exception:
				case LogType.Assert:
					return errorMessages;
			}
			return null;
		}

		private void IncLogCount(LogType type)
		{
			switch (type)
			{
			case LogType.Log:
				numInfos++;
				break;
			case LogType.Warning:
				numWarnings++;
				break;
			case LogType.Error:
			case LogType.Exception:
			case LogType.Assert:
				numErrors++;
				break;
			}
		}

		private int SequenceComparator(LogMessage lhs, LogMessage rhs)
		{
			if (lhs.sequenceNumber < rhs.sequenceNumber)
				return -1;
			if (lhs.sequenceNumber > rhs.sequenceNumber)
				return 1;
			
			return rhs.sequenceNumber - lhs.sequenceNumber;
		}

		private bool ParseTrace(string traceLine, out string namespaceName, out string className, out string methodName, out string fileName, out int lineNumber)
		{
			try
			{
			//	traceLine = "Book:SetPageEnabled(Int32, Boolean) (at Assets/Scripts/Book/Book.cs:610)";
			//	traceLine = "UnityEngine.EventSystems.VrConsole.ParseTrace (System.String traceLine) (at C:/buildslave/project/Assets/Scripts/Debug/VrConsole.cs:269)";

				// Book:SetPageEnabled(Int32, Boolean) (at Assets/Scripts/Book/Book.cs:610)
				// UnityEngine.EventSystems.VrConsole.ParseTrace (System.String traceLine) (at C:/buildslave/project/Assets/Scripts/Debug/VrConsole.cs:269)

				// Namespace.Namespace.ClassName.MethodName (argNamespace.argType, argType) (at C:/file/path/FileName.cs:123)
				// Namespace.Class:Method if static function call

				// May have Class.Method or Class:Method (depending on static or object method called)
				// See if we have either a dot or a colon before the first open bracket

				// First split into two halves, one with the callsite and one with the file path

				int traceMethodEnd = traceLine.IndexOf(')');
				string callsitePart = traceLine.Substring(0, traceMethodEnd+1);
				string filePart = traceLine.Substring(traceMethodEnd+6, traceLine.Length-traceMethodEnd-7);
				

				{
					// Split into 'Namespace.Class.Method' and '(argNamespace.argName, argName, argName)'

					int argsStart = callsitePart.LastIndexOf('(');
				//	int argsEnd = callsitePart.LastIndexOf(')');
				//	string argumentsPart = callsitePart.Substring(argsStart, argsEnd-argsStart);
					string namespaceClassAndMethod = callsitePart.Substring(0, argsStart-1);

					// Is this a static or object call?
					char methodDivider = '.';
					int firstColonPos = namespaceClassAndMethod.IndexOf(':');
					if (firstColonPos != -1)
					{
						methodDivider = ':';
					}
					
					
					int methodDividerPos = namespaceClassAndMethod.LastIndexOf(methodDivider);
					methodName = namespaceClassAndMethod.Substring(methodDividerPos+1);
				

					string namespaceAndClass = namespaceClassAndMethod.Substring(0, methodDividerPos);
					int classDot = namespaceAndClass.LastIndexOf('.');
					if (classDot == -1)
					{
						// No namespace
						className = namespaceAndClass;
						namespaceName = "";
					}
					else
					{
						className = namespaceAndClass.Substring(classDot+1, namespaceAndClass.Length-classDot-1);
						namespaceName = namespaceAndClass.Substring(0, classDot);
					}
				}

				{
					int secondColonPos = filePart.LastIndexOf(':');

					fileName = filePart.Substring (0, secondColonPos);
					if (fileName.StartsWith ("Assets/"))
						fileName = fileName.Substring (7); // Strip off initial 'Assets/' since it should be implied

					string numText = filePart.Substring (secondColonPos+1, filePart.Length-secondColonPos-1);
					lineNumber = int.Parse (numText);
				}

				return true;
			}
			catch (System.Exception)
			{
				namespaceName = className = methodName = fileName = "";
				lineNumber = 0;

				return false;
			}
		}

		public void ClearLog()
		{
			lock(mutex)
			{
				infoMessages.Clear();
				warningMessages.Clear();
				errorMessages.Clear();

				numInfos = numWarnings = numErrors = 0;

				hasMessagesChanged = true;
			}
		}

		public void ToggleInfo()
		{
			this.showInfo = !showInfo;
			this.hasMessagesChanged = true;

			UpdateButtonColours ();
		}

		public void ToggleWarnings()
		{
			this.showWarnings = !showWarnings;
			this.hasMessagesChanged = true;

			UpdateButtonColours ();
		}

		public void ToggleErrors()
		{
			this.showErrors = !showErrors;
			this.hasMessagesChanged = true;

			UpdateButtonColours ();
		}

		private void UpdateButtonColours()
		{
			Color deselectedColour = new Color (0.25f, 0.25f, 0.25f);

			SetColour(infoToggleButton, showInfo ? Color.white : deselectedColour);
			SetColour(warningToggleButton, showWarnings ? Color.yellow : deselectedColour);
			SetColour(errorToggleButton, showErrors ? Color.red : deselectedColour);

			SetText (infoButtonText, numInfos);
			SetText (warningButtonText, numWarnings);
			SetText (errorButtonText, numErrors);
		}

		private static void SetColour(Button button, Color col)
		{
			Color dullCol = col;
			dullCol.r *= 0.6f;
			dullCol.g *= 0.6f;
			dullCol.b *= 0.6f;

			ColorBlock colours = button.colors;
			colours.normalColor = dullCol;
			colours.highlightedColor = col;

			button.colors = colours;
		}

		private static void SetText(Text text, int count)
		{
			if (count > 99)
				count = 99;

			text.text = count.ToString ();
		}
	}
}
