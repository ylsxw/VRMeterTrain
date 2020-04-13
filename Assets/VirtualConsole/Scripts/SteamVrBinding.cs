using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Technie.VirtualConsole
{
	public enum ViveActionButton
	{
		Trigger,
		Grip,
		Touchpad,
		Menu,
		None
	}

	public class SteamVrBinding : ApiBinding
	{


		// Internal State

		private ViveActionButton viveActionButton = ViveActionButton.Trigger;

		private GameObject leftHand;
		private GameObject rightHand;

		private int leftHandIndex = ApiBinding.INVALID_HAND_INDEX;
		private int rightHandIndex = ApiBinding.INVALID_HAND_INDEX;

		private bool isLeftButtonDown;
		private bool isRightButtonDown;

		// Exposed Properties

		public override int LeftHandIndex
		{
			get { return leftHandIndex; }
		}
		public override int RightHandIndex
		{
			get { return rightHandIndex; }
		}

		public override GameObject LeftHand
		{
			get { return leftHand; }
		}
		public override GameObject RightHand
		{
			get { return rightHand; }
		}

		void OnEnable()
		{
			if (SteamVrApi.IsSteamVRLoaded())
			{
				SteamVrApi.EventListen ("device_connected", OnDeviceConnected);
			}
		}
		
		void OnDisable()
		{
			if (SteamVrApi.IsSteamVRLoaded())
			{
				SteamVrApi.EventRemove ("device_connected", OnDeviceConnected);
			}
		}

		// Callback from SteamVR/"device_connected"
		public void OnDeviceConnected (params object[] args)
		{
			FindHands ();
		}

		public override int FindHands()
		{
			if (!VirtualConsole.Instance.useSteamVR)
				return 0;

			if (!SteamVrApi.IsSteamVRLoaded ())
				return 0;

			viveActionButton = VirtualConsole.Instance.viveActionButton;

			List<SteamVrApi.TrackedObject> hands = new List<SteamVrApi.TrackedObject> ();
			
			leftHand = rightHand = null;
			leftHandIndex = rightHandIndex = ApiBinding.INVALID_HAND_INDEX;
			
			SteamVrApi.TrackedObject[] trackedObjs = SteamVrApi.FindAllTrackedObjects();
			
			foreach (SteamVrApi.TrackedObject obj in trackedObjs)
			{
				if (obj == null)
					continue;
				
				if (obj.IsTracked())
				{
					hands.Add(obj);
				}
			}
			
			if (hands.Count >= 2)
			{
				// Get hands via tracked object, then try and use GetDeviceIndex to sort out left from right
				int currentLeftIndex = SteamVrApi.GetLeftmostDeviceIndex();
				if (hands[0].index != currentLeftIndex)
				{
					// Swap 0 and 1 so left is at 0
					SteamVrApi.TrackedObject tmp = hands[0];
					hands[0] = hands[1];
					hands[1] = tmp;
				}
			}
			
			// Just arbitrarily assign them at the moment
			if (hands.Count >= 1)
			{
				leftHand = hands[0].gameObject;
				leftHandIndex = (int)hands[0].index;
			}
			if (hands.Count >= 2)
			{
				rightHand = hands[1].gameObject;
				rightHandIndex = (int)hands[1].index;
			}

			return hands.Count;
		}

		public override void UpdateInput()
		{
			if (!SteamVrApi.IsSteamVRLoaded ())
				return;

			isLeftButtonDown = IsViveButtonDown (leftHandIndex);
			isRightButtonDown = IsViveButtonDown (rightHandIndex);
		}

		public override bool IsInputDown(Hand hand)
		{
			if (hand == Hand.Left)
				return isLeftButtonDown;
			else
				return isRightButtonDown;
		}

		private bool IsViveButtonDown(int handIndex)
		{
			if (handIndex == -1)
				return false;
			
			SteamVrApi.ControllerDevice device = SteamVrApi.Input(handIndex);
			if (device == null)
				return false;
			
			switch (viveActionButton)
			{
				case ViveActionButton.Trigger:
				{
					Vector2 value = device.GetTrigger();
					bool isDown = value.x >= 0.2f;
					return isDown;
				}
				case ViveActionButton.Grip:
				{
					return device.GetGrip();
				}
				case ViveActionButton.Touchpad:
				{
					return device.GetTouchpad();
				}
				case ViveActionButton.Menu:
				{
					return device.GetMenu();
				}
				case ViveActionButton.None:
				{
					return false;
				}
			}
			return false;
		}
	}

} // namespace Technie.VirtualConsole
