using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

namespace Technie.VirtualConsole
{
	public class IsolatedEventSystem : EventSystem
	{
		protected override void OnEnable()
		{
			// Override this with an empty method so we do not assign EventSystem.current
		}
		
		protected override void Update()
		{
			EventSystem originalCurrent = EventSystem.current;
			current = this;
			base.Update();
			current = originalCurrent;
		}
	}
}
