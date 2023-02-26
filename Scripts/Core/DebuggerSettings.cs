using System;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(InGameLogger))]
public class DebuggerSettings : MonoBehaviour {
    private const string TOOL_MENU = "Debug Logger /";

    private static bool isLogginActive;
    private static bool isPersistantOverSceneEnabled;

    [SerializeField] private InGameConsole loggerUIprefab;
    [SerializeField] private bool persistantOverScenes;

    [SerializeField, HideInInspector] private static DebuggerSettings Instance;

    public Action<bool> OnActivationChanged;


    
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
    private static bool ToggleLoggingActive() {
        bool results = false;
        if(FindInstance()) {
            Instance.OnActivationChanged?.Invoke(true);
            results = !isLogginActive;
        }
        return results;
    }

    private void Awake() {
        if(persistantOverScenes) {
            DontDestroyOnLoad(gameObject);
        }
    }
    #region PublicMethods
    public void ActivateLogging(bool value) {
        isLogginActive= value;
        if(FindInstance() ) {
            Instance.OnActivationChanged?.Invoke(value);
        }
    }
    #endregion
}
