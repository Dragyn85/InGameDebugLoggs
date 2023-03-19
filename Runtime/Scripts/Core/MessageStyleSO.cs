using UnityEngine;

namespace DragynGames.InGameLogger {
    [CreateAssetMenu]
    public class MessageStyleSO : ScriptableObject {
        public Color textColor = Color.cyan;
        public ConsoleLogType[] appliesToLogtypes;
    }
}
