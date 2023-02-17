using System;
using UnityEngine;

[Serializable]
public struct LogMessage {
    public LogType type;
    public DateTime timeRecived;
    public string condition;
    public string stackTrace;

    public LogMessage(string condition, string stackTrace, LogType type, DateTime time) {
        this.condition = condition;
        this.stackTrace = stackTrace;
        this.type = type;
        this.timeRecived = time;
    }
}
