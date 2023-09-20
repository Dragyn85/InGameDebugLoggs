using DragynGames.Console;
using System;
using System.Collections.Generic;

namespace DragynGames.InGameLogger {

    public class CommandParser {
        const char prefix = '-';
        ICommander commander;

        private Dictionary<string, List<Action<string>>> commands = new Dictionary<string, List<Action<string>>>();

        public CommandParser(ICommander commander) {
            this.commander = commander;
            commander.OnCommand += ParseCommand;
        }

        private void ParseCommand(string input) {
            if(!input.StartsWith(prefix)) {
                return;
            }
            int firstWhiteSpace = -1;
            firstWhiteSpace = input.IndexOf(' ');
            string commandString = string.Empty;
            string commandParameter = string.Empty;
            if(firstWhiteSpace == -1) {
                commandString = input.Substring(1);
            }
            else {
                commandString = input.Substring(1, firstWhiteSpace).Trim();
                commandParameter = input.Substring(firstWhiteSpace).Trim();
            }


            if(commands.TryGetValue(commandString, out List<Action<string>> commandEvent)) {
                foreach(Action<string> action in commandEvent) {
                    action?.Invoke((commandParameter));
                }
            }
            else {
                TextToolTip.ExecuteMethod(input.TrimStart('-'));
            }

        }

        public void AddCommand(string command, Action<string> onCommandCallback) {
            if(!commands.ContainsKey(command)) {
                commands.Add(command, new List<Action<string>>());
            }
            commands[command].Add(onCommandCallback);
        }

        ~CommandParser() {
            commander.OnCommand -= ParseCommand;
        }
    }

    public interface ICommander {
        public event Action<string> OnCommand;
    }

    public interface IReciveCommand {
        public void ReciveCommand(string cmd);
    }

}
