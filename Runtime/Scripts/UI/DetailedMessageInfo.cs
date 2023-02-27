using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class DetailedMessageInfo : MonoBehaviour, IPointerClickHandler {
    [SerializeField] TMP_Text typeText;
    [SerializeField] TMP_Text timeText;
    [SerializeField] TMP_Text conditionText;
    [SerializeField] TMP_Text stackTrace;

    [SerializeField] private ToggleAbleCanvasGroup toggleAbleCanvasGroup;

    public void ShowMessage(LogMessage message) {
        typeText.SetText(message.typeName);
        timeText.SetText(message.timeReceived);
        conditionText.SetText(message.condition);
        stackTrace.SetText(message.stackTrace);

        if(toggleAbleCanvasGroup != null ) {
            toggleAbleCanvasGroup.SetVisible(true);
        }
    }

    public void OnPointerClick(PointerEventData eventData) {
        if(toggleAbleCanvasGroup != null) {
            toggleAbleCanvasGroup.SetVisible(false);
        }
    }
}
