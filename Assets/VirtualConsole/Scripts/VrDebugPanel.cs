using UnityEngine;
using System.Collections;

namespace Technie.VirtualConsole
{
	public class VrDebugPanel : MonoBehaviour
	{
		public Canvas canvas;

		public bool isLeft;

		public Transform center;

		public float panelScale = 1.0f;

		private GameObject targetHand;

		public void OnHandsDetected(HandAbstraction hands, Camera eventCamera)
		{
			targetHand = isLeft ? hands.GetLeftHand () : hands.GetRightHand ();

			this.transform.localScale = new Vector3 (0.002f * panelScale, 0.002f * panelScale, 0.002f * panelScale);

			if (canvas != null)
				canvas.worldCamera = eventCamera;

			TrackTargetHand ();
		}

		void LateUpdate()
		{
			TrackTargetHand ();
		}

		private void TrackTargetHand()
		{
			if (targetHand != null)
			{
				this.transform.position = targetHand.transform.position;
				this.transform.rotation = targetHand.transform.rotation * Quaternion.Euler(90.0f, 0.0f, 0.0f);
			}

			// Only show the canvas if we're looking at it from the front
			if (Camera.main != null) // FIXME: Backport this
			{
				float dot = Vector3.Dot (Camera.main.transform.forward, center.forward);
				canvas.enabled = dot > 0.0f;
			}
		}
	}
}
