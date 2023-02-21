using System;
using UnityEngine;
using UnityEngine.UI;
using SFB;
using TMPro;

public class SettingsWIndow : MonoBehaviour
{
    [SerializeField] private Toggle m;
    [SerializeField] private TMP_Text inputField;
    [SerializeField] private ToggleAbleCanvasGroup toggleAbleCanvasGroup;

    private LoggerOutput debuggerSettings;
    // output and findobject of typ, if null set inputfield none inactive

    private void Awake() {
        debuggerSettings = FindObjectOfType<LoggerOutput>();
        toggleAbleCanvasGroup.OnActivationChanged += HandleActivationChanged;
    }
    public void OpenFileSelection() {
        inputField.text = StandaloneFileBrowser.OpenFolderPanel("Select folder", Application.persistentDataPath, false)[0];
    }
    private void HandleActivationChanged(bool Activated) {
        inputField.text = debuggerSettings.GetSavePath();
    }
}
