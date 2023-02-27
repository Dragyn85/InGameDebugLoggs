#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace DragynGames.InGameLogger.Editor {

    [CustomEditor(typeof(LoggerOutput))]
    public class LoggerOutputCustomEditor : UnityEditor.Editor {
        LoggerOutput loggerOutput;
        SerializedProperty loggerOutputProperty;

        private void OnEnable() {
            loggerOutput = serializedObject.targetObject as LoggerOutput;
            loggerOutputProperty = serializedObject.FindProperty("customOutputPath");
        }

        public override void OnInspectorGUI() {
            base.OnInspectorGUI();
            serializedObject.Update();

            if(GUILayout.Button("Select Folder") && loggerOutput != null) {
                string newPath = loggerOutput.SelectOutputFolder();
                loggerOutputProperty.stringValue = newPath;
                EditorPrefs.SetString("InGameLoggerPath", newPath);
            }
            serializedObject.ApplyModifiedProperties();
        }
    }
}
#endif
