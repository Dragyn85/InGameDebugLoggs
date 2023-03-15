using DragynGames.InGameLogger;
using TMPro;
using UnityEngine;

public class InputFieldBlockToggleWhenActive: MonoBehaviour, IBlockToggle {

    [SerializeField] TMP_InputField inputField;
    public bool blockToggle => inputField.isFocused;
}
