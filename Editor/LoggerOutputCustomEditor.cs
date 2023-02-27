#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LoggerOutput))]
public class LoggerOutputCustomEditor : Editor
{
    LoggerOutput loggerOutput;
    SerializedProperty loggerOutputProperty;

    private void OnEnable() {
        loggerOutput = serializedObject.targetObject as LoggerOutput;
        loggerOutputProperty = serializedObject.FindProperty("customOutputPath");
    }
    
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        serializedObject.Update();

        //SerializedProperty outputPath = loggerOutputProperty.FindPropertyRelative("customOutputPath");
        if(GUILayout.Button("Select Folder") && loggerOutput != null) {
            loggerOutputProperty.stringValue = loggerOutput.SelectOutputFolder();
        }
        serializedObject.ApplyModifiedProperties();
    }
}
#endif
