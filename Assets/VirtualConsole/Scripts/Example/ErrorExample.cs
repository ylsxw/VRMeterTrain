using UnityEngine;
using System.Collections;

namespace Technie.VirtualConsole
{

	public class ErrorExample : HandTrigger
	{
		private int numErrorsTriggered;

		public override void OnHandEntered()
		{
			Debug.LogError("This is an example error message!");

			numErrorsTriggered++;
			VrDebugStats.SetStat ("Errors", "Errors triggered", numErrorsTriggered);
		}
	}
}
