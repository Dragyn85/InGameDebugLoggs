using TMPro;
using UnityEngine;

public class DebugMessage : MonoBehaviour
{
    [SerializeField] TMP_Text messageTMP_text;
    [SerializeField] TMP_Text callStackTMP_text;

    [SerializeField] Color messageColor = Color.white;
    [SerializeField] Color warningAndAssertColor = Color.yellow;
    [SerializeField] Color errorAndExceptionColor = Color.red;

    private LogMessage message;
    public LogType MessageType => message.type;
    public void SetDebugMessageInfo(LogMessage message) {

        this.message = message;
        SetTextColor();
        messageTMP_text.SetText(message.condition);
        
        callStackTMP_text.SetText(message.stackTrace);
    }

    private void SetTextColor() {
        Color color = messageColor;
        if(MessageType == LogType.Error || MessageType == LogType.Exception) {
            color = errorAndExceptionColor;
        }
        else if(MessageType == LogType.Warning || MessageType == LogType.Assert) {
            color = warningAndAssertColor;
        }
        messageTMP_text.color = color;
    }
}
