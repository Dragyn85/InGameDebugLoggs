using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class UIFilterLogTypeButton : MonoBehaviour {
    [SerializeField] private LogType logType;
    [SerializeField] private InGameConsole consoleCanvas;

    private void Awake() {
        GetComponent<Button>().onClick.AddListener(() => consoleCanvas.ToggleType(logType));
    }


}
