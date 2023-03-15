using System;
using System.Collections.Generic;

namespace DragynGames.InGameLogger {

    public class CommandParser {
        const char prefix = '-';
        ICommander commander;

        private Dictionary<string, Action<string>> commands = new Dictionary<string, Action<string>>();

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


            if(commands.TryGetValue(commandString, out Action<string> commandEvent)) {
                commandEvent?.Invoke(commandParameter);
            }

        }

        public void AddCommand(string command, Action<string> onCommandCallback) {
            commands.Add(command, onCommandCallback);
        }
    }

    public interface ICommander {
        public event Action<string> OnCommand;
    }
}
