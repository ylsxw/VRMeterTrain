using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

/** Provides access to a limited portion of the SteamVR API
 *  Instead of calling SteamVR functions directly, everything is called via reflection.
 *  This allows us to detect the SteamVR plugin at runtime, not compile time, so non-SteamVR users don't get a bunch of compile errors
 */
public class SteamVrApi
{
	/** Wrapper around SteamVR_TrackedObject
	 */
	public class TrackedObject
	{
		public Type trackedObjType;

		public System.Object trackedObject; // actually a SteamVR_TrackedObject

		public TrackedObject(System.Object steamObj)
		{
			this.trackedObjType = Type.GetType ("SteamVR_TrackedObject");

			this.trackedObject = steamObj;
		}

		/** Wrapper around SteamVR_TrackedObject.gameObject
		 */
		public GameObject gameObject
		{
			get
			{
				PropertyInfo goProperty = trackedObjType.GetProperty("gameObject");
				GameObject go = (GameObject)goProperty.GetValue(trackedObject, null);

				return go;
			}
		}

		/** Wrapper around SteamVR_TrackedObject.index
		 */
		public int index
		{
			get
			{
				FieldInfo indexField = trackedObjType.GetField ("index");
				int index = (int)indexField.GetValue (trackedObject);

				return index;
			}
		}

		public bool IsTracked()
		{
			// Retrieve the value of the k_unTrackedDeviceIndex_Hmd constant
			
			Type openVrType = FindTypeInAllAssemblies ("Valve.VR.OpenVR");
			FieldInfo untrackedDeviceField = openVrType.GetField ("k_unTrackedDeviceIndex_Hmd");
			uint untrackedDeviceIndex = (uint)untrackedDeviceField.GetValue (null);

			// Device is untracked if index is the untracked device index

			return this.index != untrackedDeviceIndex;
		}
	}

	/** Wrapper around SteamVR_Controller.Device
	 */
	public class ControllerDevice
	{
		public Type deviceType;

		public System.Object device; // Actually a SteamVR_Controller.Device

		public ControllerDevice(System.Object obj)
		{
			this.deviceType = FindTypeInAllAssemblies ("SteamVR_Controller+Device");

			this.device = obj;
		}

		public Vector3 GetTrigger()
		{
			//	device.GetAxis (Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger);

			MethodInfo getAxisMethod = deviceType.GetMethod ("GetAxis");

			ParameterInfo evrButtonIdInfo = getAxisMethod.GetParameters()[0];
			Array enumValues = Enum.GetValues (evrButtonIdInfo.ParameterType);
			object triggerEnum = FindEnum ("k_EButton_SteamVR_Trigger", enumValues);

			Vector2 result = (Vector2)getAxisMethod.Invoke (device, new object[] { triggerEnum });
			return result;
		}

		public bool GetGrip()
		{
			return GetPress ("k_EButton_Grip");
		}

		public bool GetTouchpad()
		{
			return GetPress ("k_EButton_Axis0"); // k_EButton_SteamVR_Touchpad is actually Axis0
		}

		public bool GetMenu()
		{
			return GetPress ("k_EButton_ApplicationMenu");
		}

		/** Wrapper for SteamVR_Controller.Device.GetPress(Valve.VR.EVRButtonId.k_EButton_Grip);
		 */
		private bool GetPress(string enumName)
		{
			Type arg0 = FindTypeInAllAssemblies("Valve.VR.EVRButtonId");
			MethodInfo getPressMethod = deviceType.GetMethod ("GetPress", new Type[] { arg0 } );
			
			ParameterInfo evrButtonIdInfo = getPressMethod.GetParameters()[0];
			Array enumValues = Enum.GetValues (evrButtonIdInfo.ParameterType);
			object triggerEnum = FindEnum (enumName, enumValues);
			
			bool result = (bool)getPressMethod.Invoke (device, new object[] { triggerEnum });
			return result;
		}
	}

	public delegate void EventHandler(params object[] args);

	public class EventProxy
	{
		public EventHandler handler;
		public Delegate proxyDelegate;

		public EventProxy(EventHandler handler)
		{
			this.handler = handler;
		}

		public void OnEvent(object[] args)
		{
			handler (args);
		}
	}
	public static List<EventProxy> proxies = new List<EventProxy> ();

	/** Wrapper around SteamVR_Utils.Event.Listen("device_connected", handler);
	 */
	public static void EventListen(string message, EventHandler handler)
	{
		EventProxy eventProxy = new EventProxy (handler);
		proxies.Add (eventProxy);

		Type eventType = FindTypeInAllAssemblies ("SteamVR_Utils+Event");
		MethodInfo listenMethod = eventType.GetMethod ("Listen");
		ParameterInfo handlerInfo = listenMethod.GetParameters()[1];
		Type steamHandlerType = handlerInfo.ParameterType;

		eventProxy.proxyDelegate = Delegate.CreateDelegate (steamHandlerType, eventProxy, "OnEvent");

		listenMethod.Invoke (null, new object[] { message, eventProxy.proxyDelegate } );
		return;
	}

	/** Wrapper around SteamVR_Utils.Event.Remove("device_connected", handler);
	 */
	public static void EventRemove(string message, EventHandler handler)
	{
		EventProxy proxy = null;

		foreach (EventProxy p in proxies)
		{
			if (p.handler == handler)
			{
				proxy = p;
				break;
			}
		}

		if (proxy != null)
		{
			Type eventType = FindTypeInAllAssemblies ("SteamVR_Utils+Event");
			MethodInfo removeMethod = eventType.GetMethod ("Remove");

			removeMethod.Invoke(null, new object[] { message, proxy.proxyDelegate } );

			proxies.Remove(proxy);
		}
	}

	public static bool IsSteamVRLoaded()
	{
		Type openVrType = FindTypeInAllAssemblies ("Valve.VR.OpenVR");
		Type steamVrType = FindTypeInAllAssemblies ("SteamVR");
		return openVrType != null && steamVrType != null;
	}

	/*
	 *	Equivilent to:
	 *		SteamVR_TrackedObject[] trackedObjs = GameObject.FindObjectsOfType(typeof(SteamVR_TrackedObject)) as SteamVR_TrackedObject[];
	*/
	public static TrackedObject[] FindAllTrackedObjects()
	{
		Type steamVrTrackedObjectType = FindTypeInAllAssemblies ("SteamVR_TrackedObject");
		System.Object[] objs = GameObject.FindObjectsOfType (steamVrTrackedObjectType);
		TrackedObject[] result = new TrackedObject[objs.Length];
		for (int i=0; i<objs.Length; i++)
		{
			result[i] = new TrackedObject(objs[i]);
		}

		return result;
	}

	/** Wrapper around SteamVR_Controller.Input (handIndex)
	 */
	public static ControllerDevice Input(int deviceIndex)
	{
		Type controllerType = FindTypeInAllAssemblies ("SteamVR_Controller");
		MethodInfo inputMethod = controllerType.GetMethod ("Input");
		System.Object deviceObj = inputMethod.Invoke (null, new object[] { deviceIndex } );

		if (deviceObj != null)
			return new ControllerDevice (deviceObj);
		else
			return null;
	}

	/** Wrapper around SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Leftmost)
	 */
	public static int GetLeftmostDeviceIndex()
	{
		Type controllerType = FindTypeInAllAssemblies ("SteamVR_Controller");
		MethodInfo getDeviceIndexMethod = controllerType.GetMethod ("GetDeviceIndex");

		ParameterInfo[] allParams = getDeviceIndexMethod.GetParameters();

		// Arg 0 - SteamVR_Controller.DeviceRelation.Leftmost

		ParameterInfo deviceRelationInfo = getDeviceIndexMethod.GetParameters()[0];
		Array deviceRelationEnums = Enum.GetValues (deviceRelationInfo.ParameterType);
		object relationEnum = FindEnum ("Leftmost", deviceRelationEnums);

		// Arg 1 - Valve.VR.ETrackedDeviceClass.Controller

		ParameterInfo deviceClassInfo = allParams [1];
		Array deviceClassEnums = Enum.GetValues (deviceClassInfo.ParameterType);
		object controllerEnum = FindEnum ("Controller", deviceClassEnums);

		// Arg 2 - Valve.VR.OpenVR.k_unTrackedDeviceIndex_Hmd

		Type openVrType = FindTypeInAllAssemblies ("Valve.VR.OpenVR");
		FieldInfo untrackedDeviceField = openVrType.GetField ("k_unTrackedDeviceIndex_Hmd");
		uint untrackedDeviceIndex = (uint)untrackedDeviceField.GetValue (null);

		int index = (int)getDeviceIndexMethod.Invoke (null, new object[] { relationEnum, controllerEnum, (int)untrackedDeviceIndex }); // fails
		return index;
	}

	private static Type FindTypeInAllAssemblies (string typeName)
	{
		Assembly[] allAssemblies = AppDomain.CurrentDomain.GetAssemblies ();

		foreach (Assembly a in allAssemblies)
		{
			string assemblyQualifiedName = typeName + "," + a.FullName;

			Type t = Type.GetType(assemblyQualifiedName);
			if (t != null)
				return t;
		}

		return null;
	}

	private static object FindEnum(string enumName, Array enumValues)
	{
		for (int i=0; i<enumValues.Length; i++)
		{
			if (enumValues.GetValue(i).ToString() == enumName)
				return enumValues.GetValue(i);
		}
		return null;
	}
}
