![alttext](https://img.shields.io/badge/Unity%20version-2021.3.16f1-lightgrey&?style=for-the-badge&logo=unity&color=lightgray) ![alttext](https://img.shields.io/badge/O.S-Windiws%2010-lightgrey&?style=for-the-badge&color=purple)
# In game debug logs
A tool that lets you have access to debug logs in game while playing, even in built version.

#### Customization options
* In game UI, can hide / Unhide with a UI button or keypress.
* Output log messages to a file in your applications persistant data path or a path of your choise.

#### How to use?
1. Import this package by downloading it and add it with the unity package manager
2. Drag a "InGameLogger.prefab" from the Prefabs folder inside the package into the scene.
3. Select output path on "LoggerOutput" component on the prefab instance.

#### The UI
Toggle visibilty with "L" - buttong, can be changed on the "Console Window" gameobject inside the prefabe.

click a message to get more information about it.
##### NOTE - you need a EventSystem to interact with the UI "GameObject > UI > EventSystem"

##### Settings window: 
- start/stop logging
- auto scroll when receiving message
- auto show when receiving message

showing Output path if a LoggerOutput is present.
Can be removed

#### The LoggerOutput
Is used to save logs to an file. Default output path is in the Application.persistentDataPath + Logger/output - [Timestamp].txt
