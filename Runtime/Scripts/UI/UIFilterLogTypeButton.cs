using System;
using UnityEngine;
using UnityEngine.UI;

namespace DragynGames.InGameLogger {

    [RequireComponent(typeof(Toggle))]
    public class UIFilterLogTypeButton : MonoBehaviour {
        [SerializeField] private LogType logType;
        [SerializeField] private InGameConsole consoleCanvas;

        private void Awake() {
            //GetComponent<Button>().onClick.AddListener(() => consoleCanvas.ToggleType(logType));
            Toggle toggle = GetComponent<Toggle>();

            toggle.isOn = consoleCanvas.IsFilterActive(logType);
            toggle.onValueChanged.AddListener((bool value) => consoleCanvas.FilterLogType(logType, value));
        }
    }
}
