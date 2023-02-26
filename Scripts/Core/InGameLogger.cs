using System;
using System.Collections.Generic;
using UnityEngine;

public class InGameLogger : MonoBehaviour {
    public static event Action<LogMessage> OnLogRecived;
    private bool isActive;
    private List<LogMessage> registredMessages = new List<LogMessage>();

    public bool IsActive { get { return isActive; } }

    public List<LogMessage> GetAllMessages => registredMessages;

    private void OnEnable() {
        ActivateLogTracking(true);
    }

    public void ActivateLogTracking(bool activate) {
        if(activate) {
            if(!isActive) {
                Application.logMessageReceived += HandleLogMessageReceived;
                isActive = true;
            }
        }
        else {
            Application.logMessageReceived -= HandleLogMessageReceived;
            isActive = false;
        }
    }

    private void OnDisable() {
        ActivateLogTracking(false);
    }
    private void HandleLogMessageReceived(string condition, string stackTrace, LogType type) {

        DateTime time = DateTime.Now;
        var logMessage = new LogMessage(condition, stackTrace, type, time);
        registredMessages.Add(logMessage);
        OnLogRecived?.Invoke(logMessage);
    }

    [ContextMenu("Add one of each message type")]
    public void AddTestMessages() {
        Debug.Log("Hi, I am a log");
        Debug.LogWarning("I am a warning!");
        Debug.LogError("I AM ERROR!");
    }
    [ContextMenu("Add one log message")]
    public void AddTestLogMessages() {
        Debug.Log("Hi, I am a log");
    }
}
