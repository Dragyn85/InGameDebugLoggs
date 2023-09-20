using DragynGames.InGameLogger;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class CommandDelegator : MonoBehaviour {

    [SerializeField] private CommandData[] recievers;
    private CommandParser parser;

    private void Awake() {
        ICommander commander = FindObjectOfType<InGameConsole>();
        if (commander == null) return;

        parser = new CommandParser(commander);
        foreach(CommandData data in recievers) {
            parser.AddCommand(data.Command,data.OnCommande);
        }
    }

    [Serializable]
    private class CommandData {
        [SerializeField] private string command;
        [SerializeField] private UnityEvent<string> OnCommandRecieved;
        public Action<string> OnCommande => OnCommand;
        public string Command => command;
        public void OnCommand(string cmd) {
            OnCommandRecieved.Invoke(cmd);
        }
    }
}

