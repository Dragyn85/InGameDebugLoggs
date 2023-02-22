using System;
using UnityEngine;
using UnityEngine.UI;
using SFB;
using TMPro;

public class SettingsWIndow: MonoBehaviour
{
    [SerializeField] private Toggle loggerActivationToggle;
    [SerializeField] private TMP_Text inputField;
    [SerializeField] private ToggleAbleCanvasGroup toggleAbleCanvasGroup;

    private LoggerOutput loggerOutput;
    private DebuggerSettings debuggerSettings;

    private void Awake() {
        loggerOutput = FindObjectOfType<LoggerOutput>();
        debuggerSettings = FindObjectOfType<DebuggerSettings>();
        toggleAbleCanvasGroup.OnActivationChanged += HandleActivationChanged;
        loggerActivationToggle.onValueChanged.AddListener(HandleLoggerActivationToggleChanged);
    }

    void HandleLoggerActivationToggleChanged(bool value) {
        debuggerSettings.ActivateLogging(value);
    }
    private void HandleActivationChanged(bool Activated) {
        inputField.text = loggerOutput.GetSavePath();
        loggerActivationToggle.isOn = debuggerSettings.IsLoggingActive;
    }
}
