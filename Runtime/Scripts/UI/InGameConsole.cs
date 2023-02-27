using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DragynGames.InGameLogger {

    public class InGameConsole : MonoBehaviour {
        [SerializeField] private DebugMessage debugMessagePrefab;
        [SerializeField] private Transform contenTransform;
        [SerializeField] private ScrollRect scrollRect;
        [SerializeField] private DetailedMessageInfo detailedMessageInfo;
        [SerializeField] private ToggleAbleCanvasGroup toggleAbleCavasGroup;
        [SerializeField] private bool isShowingOnMessage;
        [SerializeField] private bool autoScroll;

        private Dictionary<LogType, bool> showByType = new Dictionary<LogType, bool>();

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
        }

        private void AddDebugMessage(LogMessage message) {
            bool shouldShowMessage = showByType[message.type];
            DebugMessage debugMessage = Instantiate(debugMessagePrefab, contenTransform);
            debugMessage.SetDebugMessageInfo(message);
            debugMessage.SetDetailedMessageInfoPanel(detailedMessageInfo);
            debugMessage.gameObject.SetActive(shouldShowMessage);

            if(autoScroll) {
                StartCoroutine(ScrollToButtomNextFrame());
            }
            if(isShowingOnMessage && shouldShowMessage) {
                toggleAbleCavasGroup.SetVisible(true);
            }
        }

        private IEnumerator ScrollToButtomNextFrame() {
            yield return null;
            scrollRect.verticalNormalizedPosition = 0f;
        }

        private void ActivateTypeOfLogMessages(bool setActive, LogType affectedType) {
            DebugMessage[] displayedMessages = contenTransform.GetComponentsInChildren<DebugMessage>(true);

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

        public void ToggleType(LogType logType) {
            showByType[logType] = !showByType[logType];
            ActivateTypeOfLogMessages(showByType[logType], logType);
        }
    }
}
