# Core Tech & Tools Hiring Assignment

## Preparations

The very first thing you should do is read through these instructions. After that, send an e-mail to the email mentioned in the invite, with your suggested deadline for submission.

This means you choose your own deadline. There is no need to ask us if the deadline is OK. After that, start working on the solution and submit it no later than the deadline.

## Description

Your task is to write some code that can record log messages at runtime from games made with Unity3D engine, show them, on demand, on the UI and save them to a file, which could be uploaded to an appropriate file storage service.

Please use Unity version above 2021.1, and avoid using any experimental or deprecated/obsoleted functionality. The idea is that this should be compatible on a as wide range of setups as possible.

## Design Requirements

The tool should listen to the messages logged by the native Unity logging during runtime, both in the Unity Editor (in Play Mode) and the built player for Win64 or Android ARM64. The logged messages should be displayed in-game as they are recorded, preferably color coded, in a very simple UI that can be toggled on/off.

The tools should have a minimal configuration, containing, for example:

- Select a key to toggle on/off showing the visual on-screen log window
- Define if the window should automatically pop-up when a Debug.LogWarning and/or an LogError is received
- Define if the log should be uploaded automatically at the end of a play session

The above settings do not need to be adjustable in-game. They can be set as defaults in the Unity Editor by the developer, but if you have the time feel free to implement an on-device settings page.

- The logged messages should be saved to a file on disk, both in Editor and on device.

## Considerations

- Since this would be delivered as a UPM package, put some thought into allowing the user to configure the implementation in the actual project. How you do this is up to you.
- Ideally, you should strive for this to be useable as a drop-in package and helper tool.
- Your solution should work, standalone, with a standard Unity project, “out of the box” with as little setup as you think is reasonable.
- There should be some effort put into writing basic usage instructions, e.g. a README.md or tooltips. Make it accessible for the user.

## **Version control**

Start with cloning the provided git repo but keep it local. Do not create a new public repository or try to push to this repo, as you have no write permissions.

## Optional features, as you see fit

- The created UI to display the log in-game should have a button to Save/Upload the log which should be functional
- Same UI should display where the properly named file (project id, date, platform as Android or Win32) has been saved

> :information_source: The idea is that these files could be uploaded manually (with an in-game button press) or automatically at the end of a play session (no need to implement the uploader). For now, simply build something that could potentially facilitate this in the future.

- Access to the settings from the Unity main menu.
- UI support to filter in game different types of logged messages - Verbose/Info/Warning/Error
- Button to open the saved file (which would minimize the game and open the log in the system’s reader for the type of file)

## Other **Requirements**

- Familiarize yourself with the Resolution's code [style guide.](https://github.com/resolutiongames/programming-test-package-template/blob/master/StyleGuide.pdf) After that you can apply if you want the provided .*editorconfig* to help upholdinging it.

## Delivery

Attached is an empty UPM package template as a starting point, which will also be how the solution should be delivered. This means that the functionality should work from the context of a package, used in a Unity project.
