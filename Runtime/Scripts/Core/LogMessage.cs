using System;
using UnityEngine;

namespace DragynGames.InGameLogger {

    [Serializable]
    public struct LogMessage {
        public LogType type;
        public string typeName;
        public string timeReceived;
        public string condition;
        public string stackTrace;

        public LogMessage(string condition, string stackTrace, LogType type, DateTime time) {
            this.condition = condition;
            this.stackTrace = stackTrace;
            this.type = type;
            this.typeName = type.ToString();
            this.timeReceived = time.ToString();
        }
    }
}
