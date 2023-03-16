using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DragynGames.InGameLogger {
    [CreateAssetMenu]
    public class MessageStyleSO : ScriptableObject {
        public Color textColor;
        public ConsoleLogType[] appliesToLogtypes;
    }
}
