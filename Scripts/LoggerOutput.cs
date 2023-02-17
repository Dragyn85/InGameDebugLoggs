using UnityEngine;
using System.IO;
using System;

public class LoggerOutput : MonoBehaviour {
    static string DEFAULT_PATH = "/Logger";
    static string FILENAME = "output";
    static string FILE_EXTENSION = ".txt";

    private void AddDebugMessage(LogMessage message) {
        TextPresentableMessage newLog = new TextPresentableMessage() {
            type = message.type.ToString(),
            condition= message.condition,
            stackTrace= message.stackTrace
        };
        string newLogEntryAsJson = JsonUtility.ToJson(newLog, true);

        string path = $"{Application.persistentDataPath}{DEFAULT_PATH}";

        if(!Directory.Exists(path)) {
            Directory.CreateDirectory(path);
        }
        string filePath = $"{Application.persistentDataPath}{DEFAULT_PATH}/{FILENAME}{FILE_EXTENSION}";
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

    private struct TextPresentableMessage {
        public string type;
        public string condition;
        public string stackTrace;
    }
}
