using System;
using System.Collections.Generic;
using UnityEngine;

public class InGameLogger : MonoBehaviour {
    public static event Action<LogMessage> OnLogRecived;

    [SerializeField] private bool isActivated;

    private bool activeLastFrame;
    List<LogMessage> registredMessages = new List<LogMessage>();
    public List<LogMessage> GetAllMessages => registredMessages;
    private void Awake() {
        HandleLogMessageRegistration();
        activeLastFrame = isActivated;
    }
    

    private void HandleLogMessageRegistration() {
        Application.logMessageReceived -= HandleLogMessageReceived;
        if(isActivated) {
            Application.logMessageReceived += HandleLogMessageReceived;
        }
    }

    private void HandleLogMessageReceived(string condition, string stackTrace, LogType type) {
        
        DateTime time = DateTime.Now;
        var logMessage = new LogMessage(condition, stackTrace, type, time);
        registredMessages.Add(logMessage);
        OnLogRecived?.Invoke(logMessage);
    }
    
    private void Update() {
        if(activeLastFrame != isActivated) {
            activeLastFrame = isActivated;
            HandleLogMessageRegistration();
        }
    }
    
    [ContextMenu("Add one of each message type")]
    public void AddTestMessages() {
        Debug.Log("Hej, jag är en log");
        Debug.LogWarning("I am a warning!");
        Debug.LogError("I AM ERROR!");
    }
}
