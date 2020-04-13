using UnityEngine;
using System.Collections;

namespace Technie.VirtualConsole
{
	public class ManualBinding : ApiBinding
	{
		private int leftHandIndex = ApiBinding.INVALID_HAND_INDEX;
		private int rightHandIndex = ApiBinding.INVALID_HAND_INDEX;

		private GameObject leftHand = null;
		private GameObject rightHand = null;

		public override int LeftHandIndex { get { return leftHandIndex; } }
		public override int RightHandIndex { get { return rightHandIndex; } }
		
		public override GameObject LeftHand { get { return leftHand; } }
		public override GameObject RightHand { get { return rightHand; } }
		
		/** Try to find some suitable hands and bind to them.
		 *  Returns the amount of hands found.
		 */
		public override int FindHands()
		{
			VirtualConsole config = VirtualConsole.Instance;

			if (!config.useManualBinding)
				return 0;

			int numHands = 0;
			if (config.manualLeftHand != null)
			{
				this.leftHand = config.manualLeftHand;
				this.leftHandIndex = 0;
				numHands++;
			}

			if (config.manualRightHand != null)
			{
				this.rightHand = config.manualRightHand;
				this.rightHandIndex = 1;
				numHands++;
			}

			return numHands;
		}
		
		public override void UpdateInput()
		{

		}
		
		public override bool IsInputDown(Hand hand)
		{
			return false;
		}
	}
}
