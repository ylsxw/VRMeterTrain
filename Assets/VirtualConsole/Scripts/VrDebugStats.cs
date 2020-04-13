using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Technie.VirtualConsole
{
	public class VrDebugStats : MonoBehaviour
	{
		// Structures

		private class StatPage
		{
			private Dictionary<string, string> stats = new Dictionary<string, string>();

			public StatPage(string cat)
			{

			}

			public void SetStat(string name, string value)
			{
				stats [name] = value;
			}

			public void GetStats(List<string> keys, List<string> values)
			{
				foreach (string key in stats.Keys)
				{
					keys.Add(key);
					values.Add(stats[key]);
				}
			}
		}

		// Public Properties

		public Text[] statLines;

		// Internal State

		private static bool allowLogging = false;

		private static Dictionary<string, StatPage> pages = new Dictionary<string, StatPage>();
		private static List<string> categories = new List<string> ();

		private static bool hasStatsChanged;

		private string currentCategory = "";

		void Start ()
		{
			for (int i=0; i<statLines.Length; i++)
			{
				Text textLine = statLines[i];
				textLine.text = "";
			}
		}

		void Update ()
		{
			if (hasStatsChanged)
			{
				UpdateStats();

				hasStatsChanged = false;
			}
		}
		
		private void UpdateStats()
		{
			if (pages.Count == 0)
			{
				for (int i=0; i<statLines.Length; i++)
					statLines[i].text = "";
				return;
			}

			if (currentCategory == "" && categories.Count > 0)
				currentCategory = categories [0];

			StatPage page = FindPage (currentCategory);

			List<string> keys = new List<string> ();
			List<string> values = new List<string> ();
			page.GetStats (keys, values);

			statLines [0].text = " [ " + currentCategory + " ]";

			for (int i=0; i<statLines.Length-1; i++)
			{
				Text textLine = statLines[i+1];
				if (i < keys.Count)
				{
					textLine.text = keys[i] + ": "+ values[i];
				}
				else
				{
					textLine.text = "";
				}
			}
		}

		public void ClearStats()
		{
			pages.Clear ();
			categories.Clear ();

			currentCategory = "";

			hasStatsChanged = true;
		}

		public void PrevCategory()
		{
			ChangeCategory (-1);
		}

		public void NextCateogry()
		{
			ChangeCategory (1);
		}

		private void ChangeCategory(int direction)
		{
			if (categories.Count <= 1)
				return;
			
			int currentIndex = -1;
			for (int i=0; i<categories.Count; i++)
			{
				if (categories[i] == currentCategory)
				{
					currentIndex = i;
					break;
				}
			}
			
			if (currentIndex != -1)
			{
				currentIndex += direction;
				
				if (currentIndex >= categories.Count)
					currentIndex = 0;
				if (currentIndex < 0)
					currentIndex = categories.Count-1;
			}

			currentCategory = categories [currentIndex];

			hasStatsChanged = true;
		}

		public static void AllowLogging(bool allow)
		{
			VrDebugStats.allowLogging = allow;
		}

		public static void SetStat(string category, string name, bool value)
		{
			SetStat (category, name, value.ToString ());
		}

		public static void SetStat(string category, string name, int value)
		{
			SetStat (category, name, value.ToString ());
		}

		public static void SetStat(string category, string name, string value)
		{
			if (!allowLogging)
				return;

			StatPage page = FindPage (category);

			page.SetStat (name, value);

			hasStatsChanged = true;
		}

		private static StatPage FindPage(string categoryName)
		{
			if (categoryName == null)
				categoryName = "";

			if (pages.ContainsKey(categoryName))
			{
				// Return the existing page
				return pages[categoryName];
			}
			else
			{
				// Add a new page for this category
				StatPage page = new StatPage(categoryName);
				pages[categoryName] = page;

				// Add the category to the category list
				categories.Add(categoryName);

				categories.Sort();

				return page;
			}
		}
	}
}
