
Technie Virtual Console
=======================

Setup
-----

To add the virtual console to your project simply add the 'Virtual Console' prefab (from `Assets/Technie/VirtualConsole/Prefabs/Virtual Console.prefab`) to your scene.

It is assumed that you already have your project set up for VR. If you are using SteamVR then controllers for left and right hands will be detected automatically. If are using another API then see the section 'Manual Binding'.

Example Scene
-------------

There's an example scene in `Assets/Technie/VirtualConsole/Scenes/Example1.scene`. This contains the Virtual Console prefab, the SteamVR camera prefab, a minimal environment, and some trigger boxes.

Putting a hand inside the trigger boxes will trigger different kinds of log/stat information to be created.

Functionality
-------------

The 'Virtual Console' prefab can be included normally within your scene, and enabled/disabled at runtime by enabling/disabling the root game object. All customisation options are exposed on the `VirtualConsole` component on the root of the prefab.

By default the console will delete itself if running in a release build (ie. 'Development Build' in Build Settings dialog is unticked). This functionality can be turned off with the `Only in debug builds` option on the VirtualConsole component.

If you would rather not have any additional loading overhead for release builds then you can spawn the Virtual Console prefab dynamically as your game loads.

### Console Panel ###

This displays messages sent to Unity's console via the usual `Debug.Log()`, `Debug.LogWarning()` and `Debug.LogError()`. Uncaught exceptions will also be shown, with the stack trace reformatted to be more space efficient.

The buttons at the bottom can be used to toggle visibility of info, warnings and errors separately. The 'Clear' button will clear all log messages shown on the VR console.

### Stats Panel ###

Stats are a different way of inspecting internal game state. They are paticularly useful for watching a fast changing internal values - such as what state a state machine is in, or internal cooldown values for gameplay mechanic. Values which if output to Debug.Log would heavily spam the console and hide other output.

These are logged by calling `VrDebugStats.SetStat()`. Stats are a name with an associated value (plus an optional category). Setting a stat either creates a new one if one does not already exist, or overwrites the existing value if one does exist.

Pressing the 'Clear' button on the vr panel will clear all stats. The arrows can be used to cycle through different categories of stats.

For an example usage, see `Assets/Technie/VirtualConsole/Scripts/Example/InfoExample.cs`

SteamVR
-------

By default the virtual consoles will find the left and right controllers automatically when your game starts. By default the debug ui will respond to the SteamVR controller's trigger button. To change this use the drop down menu on the `VirtualConsole` component and choose a button your game does not use. If you want full control of button behaviour, see the section 'Manual Input'.

Manual Binding
--------------

You can control the placement of the consoles yourself by using 'manual binding'. Use this if you're using something other than SteamVR, or if you want finer grained control of their placement.

On the `VirtualConsole` component untick `use SteamVR` and tick `Use Manual Binding`. Then drag in references into `Manual Left Hand` and `Manual Right Hand` (or assign them via script). The virtual consoles will be parented to these game objects. Then handle input as described in the 'Manual Input' section.

Manual Input
------------

For finer control over button input you can perform manual input handling. To do this change the button assignments on the `VirtualConsole` component to 'None'. Then use the interface on the `Technie.VirtualConsole.VirtualConsole` component to handle input yourself. You'll want to use `VirtualConsole.GetHand()` to determine which hand is which, then when input is detected by your game check `VirtualConsole.HasTarget()` to see if the user is pointing at a debug panel. If they are, then call `VirtualConsole.TriggerInput()`. If they are not then handle the input in your game as normal.

In general you should only use public functions on the `Technie.VirtualConsole.VirtualConsole` component, as these will be stable between releases.

Planned Features
-----------------

Support for Oculus Touch and Playstation Move tracked controllers and Unity's native VR api.

'Time' panel with pause and time scale controls.

'Performance' panel with FPS graph and other performance metrics.

Decouple panel display and laser position (so can have consoles floatin in the air and still point at them).

Configurable panel sizes to trade off information density vs. intrusiveness.

Functionality to detach panels from hands and position in world space and back again.

Extension system so games can add custom debug panels.

Scale factor on `VirtualConsole` component to scale up whole ui (to compensate for games being built at different scales)

Problems? Feature Requests? Bugs?
---------------------------------

Send an email to `technie@triangularpixels.com` for support and feature suggestions.

Please include your Unity version, OS and VR platform in any support emails. If reporting a bug then if you include a (small!) reproduction project with instructions on how to reproduce your bug then we'll be able to fix things *much* quicker. Thanks!





