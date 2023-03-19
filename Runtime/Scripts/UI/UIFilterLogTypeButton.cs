using System;
using UnityEngine;
using UnityEngine.UI;

namespace DragynGames.InGameLogger {

    [RequireComponent(typeof(Toggle))]
    public class UIFilterLogTypeButton : MonoBehaviour {
        [SerializeField] private ConsoleLogType logType;
        [SerializeField] private InGameConsole consoleCanvas;

        private Toggle toggle;

        private void Start() {
            toggle = GetComponent<Toggle>();

            toggle.isOn = consoleCanvas.IsFilterActive(logType);
            toggle.onValueChanged.AddListener((bool value) => consoleCanvas.FilterLogType(logType, value));
        }
    }
}
