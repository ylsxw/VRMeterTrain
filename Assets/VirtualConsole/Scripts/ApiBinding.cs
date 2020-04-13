using UnityEngine;
using System.Collections;

namespace Technie.VirtualConsole
{
	public abstract class ApiBinding : MonoBehaviour
	{
		public const int INVALID_HAND_INDEX = -1;

		public abstract int LeftHandIndex { get; }
		public abstract int RightHandIndex { get; }

		public abstract GameObject LeftHand { get; }
		public abstract GameObject RightHand { get; }

		/** Try to find some suitable hands and bind to them.
		 *  Returns the amount of hands found.
		 */
		public abstract int FindHands();

		public abstract void UpdateInput();

		public abstract bool IsInputDown(Hand hand);
	}
}
