using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Technie.VirtualConsole
{
	public class HandAbstraction : MonoBehaviour
	{
		public Material laserMaterial;

		public Sprite cursorSprite;
		public Material cursorMaterial;

		public SteamVrBinding steamVrBinding;
		public ManualBinding manualBinding;

		// Internal State

		private WandInputModule wandInputModule;

		private ApiBinding activeBinding;

		private UiLaser leftLaser;
		private UiLaser rightLaser;

		private bool wasLeftDown;
		private bool wasRightDown;

		private bool triggerLeft;
		private bool triggerRight;

		private float findHandsTimer;

		void OnEnable()
		{

		}
		
		void OnDisable()
		{

		}

		void Start()
		{
			// Always call this on start so we refetch hands if we're dynamically loaded as a prefab after SteamVR has sent all of it's controller events

			FindHands();
		}

		private void FindHands()
		{
			// Lazily create the wand input module

			if (wandInputModule == null)
			{
				GameObject eventSystemObj = new GameObject ("Isolated Event System");
				eventSystemObj.transform.SetParent (this.transform, false);
				
				eventSystemObj.gameObject.AddComponent<IsolatedEventSystem> ();
				
				wandInputModule = eventSystemObj.gameObject.AddComponent<WandInputModule> ();
				wandInputModule.CursorSprite = cursorSprite;
				wandInputModule.CursorMaterial = cursorMaterial;
			}

			// Lazily create the lasers

			if (leftLaser == null)
			{
				leftLaser = CreateLaser();
			}
			if (rightLaser == null)
			{
				rightLaser = CreateLaser();
			}

			// Do Api specific binding

			if (activeBinding == null)
			{
				// No active binding, try all known bindings to see what catches on

				if (steamVrBinding.FindHands () > 0)
				{
					// SteamVR found hands, so use SteamVR from now on
					activeBinding = steamVrBinding;
				}
				else if (manualBinding.FindHands () > 0)
				{
					activeBinding = manualBinding;
				}
				// other api bindings here...

			}
			else
			{
				// We have an active binding, check it again to see if it found any more hands
				activeBinding.FindHands();
			}

			if (activeBinding != null)
			{
				// We have a new binding, so hook up all the things

				wandInputModule = GameObject.FindObjectOfType(typeof(WandInputModule)) as WandInputModule;
				if (wandInputModule != null)
				{
					wandInputModule.OnHandsDetected(this);
				}
				
				leftLaser.OnHandDetected(activeBinding.LeftHandIndex, activeBinding.LeftHand, wandInputModule);
				rightLaser.OnHandDetected(activeBinding.RightHandIndex, activeBinding.RightHand, wandInputModule);
				
				VrDebugPanel[] panels = GameObject.FindObjectsOfType(typeof(VrDebugPanel)) as VrDebugPanel[];
				foreach (VrDebugPanel panel in panels)
				{
					panel.OnHandsDetected(this, wandInputModule.GetControllerCamera());
				}
			}
		}

		private UiLaser CreateLaser()
		{
			GameObject laser = new GameObject ("Ui Laser");
			laser.transform.SetParent (this.transform, false);

			UiLaser laserComponent = laser.AddComponent<UiLaser> ();
			laserComponent.CreateBeam (laserMaterial);

			return laserComponent;
		}

		public GameObject GetLeftHand()
		{
			if (activeBinding != null)
				return activeBinding.LeftHand;
			return null;
		}

		public GameObject GetRightHand()
		{
			if (activeBinding != null)
				return activeBinding.RightHand;
			return null;
		}

		void Update()
		{
			// If we don't have both hands then keep checking every second until we do (since SteamVR can be a bit slow sometimes)
			if (activeBinding == null || activeBinding.LeftHand == null || activeBinding.RightHand == null)
			{
				findHandsTimer += Time.unscaledDeltaTime;
				if (findHandsTimer > 1.0f)
				{
					findHandsTimer = 0.0f;

					FindHands();
				}
			}

			if (activeBinding != null)
			{
				activeBinding.UpdateInput();

				// Now do edge detection and dispatch

				UpdateInput(Hand.Left, activeBinding.LeftHandIndex, activeBinding.LeftHand, ref wasLeftDown);
				UpdateInput(Hand.Right, activeBinding.RightHandIndex, activeBinding.RightHand, ref wasRightDown);

				// Clear manual input state

				triggerLeft = triggerRight = false;
			}
		}

		private void UpdateInput(Hand hand, int handIndex, GameObject handObj, ref bool wasButtonDown)
		{
			if (wandInputModule == null)
				return;
			
			if (handIndex != -1)
			{
				bool isDown = activeBinding.IsInputDown(hand);
				
				// Add manual input trigger
				if (hand == Hand.Left)
					isDown |= triggerLeft;
				else
					isDown |= triggerRight;
				
				int inputIndex = wandInputModule.GetHandToLocalIndex(handObj);
				
				if (isDown && !wasButtonDown)
					wandInputModule.LatchButtonDown(inputIndex);
				
				if (wasButtonDown && !isDown)
					wandInputModule.LatchButtonUp(inputIndex);
				
				wasButtonDown = isDown;
			}
		}

		public bool HasTarget(Hand targetHand)
		{
			if (targetHand == Hand.Left)
			{
				return leftLaser != null ? leftLaser.IsPointingAtPanel() : false;
			}
			else if (targetHand == Hand.Right)
			{
				return rightLaser != null ? rightLaser.IsPointingAtPanel() : false;
			}
			return false;
		}

		public void TriggerInput(Hand targetHand)
		{
			if (targetHand == Hand.Left)
				triggerLeft = true;
			else if (targetHand == Hand.Right)
				triggerRight = true;
		}
	}
}
