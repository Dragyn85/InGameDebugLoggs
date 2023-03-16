using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DragynGames.InGameLogger {

    public class InGameConsole : MonoBehaviour, ICommander{
        public event Action<string> OnCommand;
        public static Action<string> OnAnyConsoleInput;

        [SerializeField] private DebugMessage debugMessagePrefab;
        [SerializeField] private Transform contenTransform;
        [SerializeField] private ScrollRect scrollRect;
        [SerializeField] private DetailedMessageInfo detailedMessageInfo;
        [SerializeField] private ToggleAbleCanvasGroup toggleAbleCavasGroup;
        [SerializeField] private bool isShowingOnMessage;
        [SerializeField] private bool autoScroll;
        [SerializeField] private TMP_InputField inputField;
        [SerializeField] MessageStyleSO[] messageStyleSOArray;

        private Dictionary<ConsoleLogType, bool> showByType = new Dictionary<ConsoleLogType, bool>();

        public bool IsAutoScrolling {
            get {
                return autoScroll;
            }
            set {
                autoScroll = value;
            }
        }

        public bool IsShowingOnMessage {
            get {
                return isShowingOnMessage;
            }
            set {
                isShowingOnMessage = value;
            }
        }

        private void Awake() {
            AddLogTypesWithDefaultShowValue();
            inputField.onSubmit.AddListener(inputField_OnSubmit);
        }

        private void inputField_OnSubmit(string consoleInput) {
            if(string.IsNullOrEmpty(consoleInput)) {
                return;
            }

            DateTime time = DateTime.Now;
            LogMessage log = new LogMessage(consoleInput, Environment.StackTrace, ConsoleLogType.ManualEntry, time);
            AddDebugMessage(log);

            OnCommand?.Invoke(consoleInput);
            OnAnyConsoleInput?.Invoke(consoleInput);

            inputField.SetTextWithoutNotify(string.Empty);
            inputField.ActivateInputField();
        }
        

        private void AddDebugMessage(LogMessage message) {
            MessageStyleSO messageStyleSO = GetLogStyleSO(message.type);
            bool shouldShowMessage = showByType[message.type];
            DebugMessage debugMessage = Instantiate(debugMessagePrefab, contenTransform);
            debugMessage.SetDebugMessageInfo(message, messageStyleSO);
            debugMessage.SetDetailedMessageInfoPanel(detailedMessageInfo);
            debugMessage.gameObject.SetActive(shouldShowMessage);

            if(autoScroll) {
                StartCoroutine(ScrollToButtomNextFrame());
            }
            if(isShowingOnMessage && shouldShowMessage) {
                toggleAbleCavasGroup.SetVisible(true);
            }
        }

        private MessageStyleSO GetLogStyleSO(ConsoleLogType type) {
            ConsoleLogType consoleLogType = (ConsoleLogType)type;
            var style =messageStyleSOArray.FirstOrDefault(t => t.appliesToLogtypes.Contains(consoleLogType));
            if (style == null) {
                style = messageStyleSOArray[0];
            }
            return style;

        }

        private IEnumerator ScrollToButtomNextFrame() {
            yield return null;
            scrollRect.verticalNormalizedPosition = 0f;
        }

        private void ActivateTypeOfLogMessages(ConsoleLogType affectedType, bool setActive) {
            DebugMessage[] displayedMessages = contenTransform.GetComponentsInChildren<DebugMessage>(true);

            for(int i = 0; i < displayedMessages.Length; i++) {
                var displayedMessage = displayedMessages[i];
                if(displayedMessage.MessageType == affectedType) {
                    displayedMessage.gameObject.SetActive(setActive);
                }
            }
        }

        private void AddLogTypesWithDefaultShowValue() {
            showByType.Add(ConsoleLogType.ManualEntry, true);
            showByType.Add(ConsoleLogType.Log, true);
            showByType.Add(ConsoleLogType.Error, true);
            showByType.Add(ConsoleLogType.Warning, true);
            showByType.Add(ConsoleLogType.Exception, true);
            showByType.Add(ConsoleLogType.Assert, true);
        }
       
        private void OnEnable() {
            InGameLogger.OnLogRecived += AddDebugMessage;
        }

        private void OnDisable() {
            InGameLogger.OnLogRecived -= AddDebugMessage;
        }

        public void FilterLogType(ConsoleLogType logType, bool setFilterActive) {
            showByType[logType] = setFilterActive;
            ActivateTypeOfLogMessages(logType, showByType[logType]);
        }

        public void ToggleType(ConsoleLogType logType) {
            FilterLogType(logType, !showByType[logType]);
        }

        public bool IsFilterActive(ConsoleLogType logType) {
            if(showByType.TryGetValue(logType, out bool value)) {
                return value;
            }
            return false;
        }
        
    }
    public enum ConsoleLogType {
        Log, Warning, Exception, Assert, Error, ManualEntry

    }
}


