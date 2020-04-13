using UnityEngine;
using System.Collections;

namespace Technie.VirtualConsole
{
	public class HandTrigger : MonoBehaviour
	{
		public BoxCollider area;

		private HandAbstraction hands;

		private bool wasInBox;

		void Start ()
		{
			hands = GameObject.FindObjectOfType (typeof(HandAbstraction)) as HandAbstraction;
		}

		void Update ()
		{
			if (hands != null)
			{
				bool isInBox = IsInBox(hands.GetLeftHand()) || IsInBox(hands.GetRightHand());

				bool sendEvent = (isInBox && !wasInBox);
				wasInBox = isInBox;

				if (sendEvent)
				{
					OnHandEntered();
				}
			}
		}

		private bool IsInBox(GameObject obj)
		{
			if (obj == null)
				return false;

			return area.bounds.Contains (obj.transform.position);
		}

		public virtual void OnHandEntered()
		{
			
		}
	}
}
