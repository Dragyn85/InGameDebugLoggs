using DragynGames.Console;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ConsoleAvailable]
public class TestCommandStuff : MonoBehaviour
{
    [SerializeField]
    [ConsoleAction]
    string Testar(int hej, TestCommandStuff hopp) {
        Debug.Log($"inputing {hej}, {hopp}");
        return "executed";
    }

    [ConsoleAction]
    void Glad(int hej, TestCommandStuff grad) {

    }

    [ConsoleAction]
    string Glass(string fluff, float flacky) {
        return $"Jag äter Glass {fluff} om dagen och tycker det är {flacky} gott på en skala mellan 0 - {flacky} ";
    }

    [ConsoleAction]
    static void MyStatic(float ett, float tva) {

    }
}
