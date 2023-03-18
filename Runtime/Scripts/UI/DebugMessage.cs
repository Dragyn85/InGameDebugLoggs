using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DragynGames.InGameLogger {

    public class DebugMessage : MonoBehaviour, IPointerClickHandler {
        [SerializeField] private TMP_Text messageTMP_text;
        MessageStyleSO style;
        
        private LogMessage message;
        private DetailedMessageInfo detailedMessageInfo;

        public ConsoleLogType MessageType {
            get {
                return message.type;
            }
        }

        public void OnPointerClick(PointerEventData eventData) {
            detailedMessageInfo.ShowMessage(message);
        }

        public void SetDebugMessageInfo(LogMessage message,MessageStyleSO messageStyleSO) {
            this.style= messageStyleSO;
            this.message = message;
            SetTextColor();
            messageTMP_text.SetText(message.condition, messageStyleSO);
        }

        private void SetTextColor() {
            Color color = style.textColor;
            
            messageTMP_text.color = color;
        }

        public void SetDetailedMessageInfoPanel(DetailedMessageInfo detailedMessageInfo) {
            this.detailedMessageInfo = detailedMessageInfo;
        }
    }
}
