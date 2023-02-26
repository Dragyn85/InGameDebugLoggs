using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsWIndow : MonoBehaviour {
    [SerializeField] private Toggle loggerActivationToggle;
    [SerializeField] private Toggle autoScrollToggle;
    [SerializeField] private Toggle autoShowOnMessage;
    [SerializeField] private TMP_Text outputFolderText;
    [SerializeField] private ToggleAbleCanvasGroup toggleAbleCanvasGroup;

    private LoggerOutput loggerOutput;
    private InGameLogger inGameLogger;
    private InGameConsole inGameConsole;

    private void Awake() {
        loggerOutput = FindObjectOfType<LoggerOutput>();
        inGameLogger = FindObjectOfType<InGameLogger>();
        inGameConsole = FindObjectOfType<InGameConsole>();

        EventRegistration();
    }

    private void EventRegistration() {
        toggleAbleCanvasGroup.OnActivationChanged += HandleActivationChanged;

        loggerActivationToggle.onValueChanged.AddListener(HandleLoggerActivationToggleChanged);
        autoScrollToggle.onValueChanged.AddListener(HandleOnAutoScrollChanged);
        autoShowOnMessage.onValueChanged.AddListener(HandleOnAutoShowMessageChanged);
    }

    #region Handle settings changed methods
    private void HandleOnAutoShowMessageChanged(bool value) {
        inGameConsole.IsShowingOnMessage = value;
    }

    private void HandleOnAutoScrollChanged(bool value) {
        inGameConsole.IsAutoScrolling = value;
    }

    void HandleLoggerActivationToggleChanged(bool value) {
        inGameLogger.ActivateLogTracking(value);
    }
    #endregion

    #region Update window visuals
    private void HandleActivationChanged(bool isVisible) {
        if(isVisible) {
            ReadLoggerOutputSettings();
            ReadInGameLoggerSettings();
            ReadInGameConsoleSettings();

        }
    }

    private void ReadInGameConsoleSettings() {
        if(inGameConsole != null) {
            autoScrollToggle.isOn = inGameConsole.IsAutoScrolling;
            autoShowOnMessage.isOn = inGameConsole.IsShowingOnMessage;
        }
    }

    private void ReadInGameLoggerSettings() {
        if(inGameLogger != null) {
            loggerActivationToggle.isOn = inGameLogger.IsActive;
        }
        else {
            loggerActivationToggle.enabled = false;
        }
    }

    private void ReadLoggerOutputSettings() {
        if(loggerOutput != null) {
            outputFolderText.SetText(loggerOutput.GetSavePath());
        }
        else {
            outputFolderText.enabled = false;
        }
    }
    #endregion

    private void OnDestroy() {
        toggleAbleCanvasGroup.OnActivationChanged -= HandleActivationChanged;
    }
}
