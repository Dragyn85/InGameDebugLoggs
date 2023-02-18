using UnityEngine;
using System.IO;
using System;
using UnityEditor;

public class LoggerOutput : MonoBehaviour {
    static string DEFAULT_PATH = "/Logger";
    static string FILENAME = "output";
    static string FILE_EXTENSION = ".txt";

    [SerializeField, HideInInspector] private string customOutputPath;

    private void AddDebugMessage(LogMessage message) {
        string newLogEntryAsJson = JsonUtility.ToJson(message, true);
        string path;
        if(string.IsNullOrEmpty(customOutputPath)) {
            path = $"{Application.persistentDataPath}{DEFAULT_PATH}";
        }
        else {
            path = customOutputPath;
        }

        if(!Directory.Exists(path)) {
            Directory.CreateDirectory(path);
        }
        string filePath = $"{path}/{FILENAME}{FILE_EXTENSION}";
        try {
            File.AppendAllText(filePath, newLogEntryAsJson);
        }
        catch(Exception e) {
            Debug.LogException(e);
        }
    }

    private void OnEnable() {
        InGameLogger.OnLogRecived += AddDebugMessage;
    }
    private void OnDisable() {
        InGameLogger.OnLogRecived -= AddDebugMessage;
    }

    public void SetCustomOutputFolder(string path) {
        customOutputPath = path;
    }
}
