using UnityEngine;
using System.Collections;

namespace Technie.VirtualConsole
{
	public enum Hand
	{
		Left,
		Right
	}

	/** This class serves to expose the public API for a host game to interact with the Virtual Console.
	 *  Note to self - assume all public functions in here are callable by the host game.
	 *  Note to users - *only* call public functions in this class. Calling other functions will result in undefined behaviour.
	 */
	public class VirtualConsole : MonoBehaviour
	{
		public bool onlyInDebugBuilds = true;

		[Header("SteamVR")]
		public bool useSteamVR = true;
		public ViveActionButton viveActionButton = ViveActionButton.Trigger;

		[Header("Manual Binding")]
		public bool useManualBinding = false;
		public GameObject manualLeftHand = null;
		public GameObject manualRightHand = null;

		// Singleton

		private static VirtualConsole instance;
		public static VirtualConsole Instance { get { return instance; } }

		// Internal State

		private HandAbstraction handAbstraction;

		void Start ()
		{
			if (onlyInDebugBuilds && !Debug.isDebugBuild)
			{
				GameObject.Destroy(this.gameObject);
			}
			else
			{
				this.handAbstraction = GetComponentInChildren<HandAbstraction> ();
			}
		}

		public void OnEnable()
		{
			VrDebugStats.AllowLogging (true);

			VirtualConsole.instance = this;
		}

		public void OnDisable()
		{
			VrDebugStats.AllowLogging (false);
		}

		/** External API for host game.
		 *  Retrives the GameObject for a given hand.
		 */
		public GameObject GetHand(Hand hand)
		{
			if (handAbstraction == null)
				return null;
			
			return hand == Hand.Left ? handAbstraction.GetLeftHand () : handAbstraction.GetRightHand ();
		}

		/** External API for host game.
		 *  Detect if a specified hand is pointing at a virtual console panel.
		 *  Useful if the host game wants to redirect input to the virtual console only when nessesary.
		 */
		public bool HasTarget(Hand targetHand)
		{
			if (handAbstraction == null)
				return false;
			
			return handAbstraction.HasTarget (targetHand);
		}

		/** External API for host game.
		 *  Host game can call this to manually trigger an input press for the specified hand.
		 *  Useful for when the game is already doing it's own input handling and doesn't want our own input handling active.
		 */
		public void TriggerInput(Hand targetHand)
		{
			if (handAbstraction == null)
				return;
			
			handAbstraction.TriggerInput (targetHand);
		}
	}
}
