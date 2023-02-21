
using System.Runtime.CompilerServices;
using TMPro;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(InGameLogger))]
public class DebuggerSettings : MonoBehaviour {
    static private bool logginActive;

    [SerializeField] private LoggerCanvas loggerUIprefab;
    [SerializeField] private bool persistantOverScenes;

    [SerializeField, HideInInspector] private static DebuggerSettings Instance;

#if UNITY_EDITOR
    [MenuItem("DebugLogger/Add in Game UI")]
    public static void AddUI() {

        if(!FindInstance()) {
            return;
        }
        var instancedUI = FindObjectOfType<LoggerCanvas>();

        if(instancedUI == null && Instance.loggerUIprefab != null) {
            PrefabUtility.InstantiatePrefab(Instance.loggerUIprefab, Instance.transform);
        }
        else {
            Debug.Log("Game UI is allready present in current scene or no prefab is set on the gameobject" + Instance.gameObject);
        }
    }
    
    [MenuItem("DebugLogger/Add output to file")]
    public static void AddOutput() {
        if(!FindInstance()) {
            return;
        }
        if(Instance.GetComponent<LoggerOutput>() == null) {
            Instance.gameObject.AddComponent<LoggerOutput>();
        }
        else {
            Debug.Log("Game log output is already present in current scene");
        }
    }
    [MenuItem("DebugLogger/Select output Folder")]
    public static void SelectOutputFolder() {
        string path = EditorUtility.OpenFolderPanel("Select save folder", Application.dataPath, "DebugLogOutput");
        var loggerOutput = FindObjectOfType<LoggerOutput>();
        if(loggerOutput != null && !string.IsNullOrEmpty(path)) {
            loggerOutput.SetOutputFolder(path);
        }
    }
#endif
    private static bool FindInstance() {
        if(Instance == null) {
            Instance = FindObjectOfType<DebuggerSettings>();
        }

        if(Instance == null) {
            Debug.Log("No CustomDebugger in scene, Drag out a \"GameLogger.prefab\" into the scene to use this feature");
            return false;
        }
        return true;
    }

    private void OnAwake() {
        if(persistantOverScenes) {
            DontDestroyOnLoad(gameObject);
        }
    }
}
