using System.IO;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(InGameLogger))]
public class DebuggerSettings : MonoBehaviour {
    static private bool logginActive;

    [SerializeField] private LoggerCanvas loggerUIprefab;
    [SerializeField] bool persistantOverScenes;

    [SerializeField, HideInInspector] private static DebuggerSettings Instance;

    [MenuItem("DebugLogger/Add in Game UI")]
    public static void AddUI() {

        if(!FindInstance()) {
            return;
        }
        var instancedUI = FindObjectOfType<LoggerCanvas>();

        if(instancedUI == null) {
            PrefabUtility.InstantiatePrefab(Instance.loggerUIprefab, Instance.transform);
        }
        else {
            Debug.Log("Game UI is allready present in current scene");
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
        
    }
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
    public static void ToggleInGameLoggerActive() {

    }

    private void OnAwake() {
        if(persistantOverScenes) {
            DontDestroyOnLoad(gameObject);
        }
    }
}
