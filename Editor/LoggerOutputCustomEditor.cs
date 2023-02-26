#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LoggerOutput))]
public class LoggerOutputCustomEditor : Editor
{
    LoggerOutput loggerOutout;

    private void OnEnable() {
        loggerOutout = target as LoggerOutput;
    }
    
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        serializedObject.Update();
        
        if(GUILayout.Button("Select Folder") && loggerOutout != null) {
            loggerOutout.SelectOutputFolder();
        }
        serializedObject.ApplyModifiedProperties();
    }
}
#endif
