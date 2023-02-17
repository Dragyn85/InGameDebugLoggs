using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoggerCanvas : MonoBehaviour {
    [SerializeField] DebugMessage debugMessagePrefab;
    [SerializeField] Transform contenTransform;
    [SerializeField] ScrollRect scrollRect;
    Dictionary<LogType,bool> showByType= new Dictionary<LogType,bool>();

    private void Awake() {
        AddLogTypesWithDefaultShowValue();
    }

    private void AddDebugMessage(LogMessage message) {
        DebugMessage debugMessage = Instantiate(debugMessagePrefab, contenTransform);
        debugMessage.SetDebugMessageInfo(message);
        debugMessage.gameObject.SetActive(showByType[debugMessage.MessageType]);
        scrollRect.verticalNormalizedPosition = 0f;
    }

    private void ActivateTypeOfLogMessages(bool setActive, LogType affectedType) {
        DebugMessage[] displayedMessages =  contenTransform.GetComponentsInChildren<DebugMessage>(true);
        
        for(int i = 0; i < displayedMessages.Length; i++) {
            var displayedMessage = displayedMessages[i];
            if(displayedMessage.MessageType == affectedType) {
                displayedMessage.gameObject.SetActive(setActive);
            }
        }
    }
    private void AddLogTypesWithDefaultShowValue() {
        showByType.Add(LogType.Log, true);
        showByType.Add(LogType.Error, true);
        showByType.Add(LogType.Warning, true);
        showByType.Add(LogType.Exception, true);
        showByType.Add(LogType.Assert, true);
    }

    private void OnEnable() {
        InGameLogger.OnLogRecived += AddDebugMessage;
    }
    private void OnDisable() {
        InGameLogger.OnLogRecived -= AddDebugMessage;
    }
    public void ToggleLogActivation() {
        var type = LogType.Log;
        showByType[type] = !showByType[type];
        ActivateTypeOfLogMessages(showByType[type], type);
    }
    public void ToggleWarningActivation() {
        var type = LogType.Warning;
        showByType[type] = !showByType[type];
        ActivateTypeOfLogMessages(showByType[type], type);
        var type2 = LogType.Assert;
        showByType[type2] = !showByType[type2];
        ActivateTypeOfLogMessages(showByType[type2], type2);
    }
    public void ToggleErrorActivation() {
        var type = LogType.Error;
        showByType[type] = !showByType[type];
        ActivateTypeOfLogMessages(showByType[type], type);
        var type2 = LogType.Exception;
        showByType[type2] = !showByType[type2];
        ActivateTypeOfLogMessages(showByType[type2], type2);
    }
}
