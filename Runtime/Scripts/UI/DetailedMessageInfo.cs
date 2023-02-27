using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DragynGames.InGameLogger {

    public class DetailedMessageInfo : MonoBehaviour, IPointerClickHandler {
        [SerializeField] private TMP_Text typeText;
        [SerializeField] private TMP_Text timeText;
        [SerializeField] private TMP_Text conditionText;
        [SerializeField] private TMP_Text stackTrace;

        [SerializeField] private ToggleAbleCanvasGroup toggleAbleCanvasGroup;

        public void ShowMessage(LogMessage message) {
            typeText.SetText(message.typeName);
            timeText.SetText(message.timeReceived);
            conditionText.SetText(message.condition);
            stackTrace.SetText(message.stackTrace);

            if(toggleAbleCanvasGroup != null) {
                toggleAbleCanvasGroup.SetVisible(true);
            }
        }

        public void OnPointerClick(PointerEventData eventData) {
            if(toggleAbleCanvasGroup != null) {
                toggleAbleCanvasGroup.SetVisible(false);
            }
        }
    }
}
