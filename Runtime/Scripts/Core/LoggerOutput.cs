using UnityEngine;
using System.IO;
using System;
using UnityEditor;
using System.Text;

namespace DragynGames.InGameLogger {

    public class LoggerOutput : MonoBehaviour {
        static string DEFAULT_PATH = "/Logger";
        static string FILENAME = "output";
        static string FILE_EXTENSION = ".txt";

        [Tooltip("Toggle on to get new files each play session")]
        [SerializeField] private bool newFileOnSession;

        [SerializeField] public string customOutputPath;

        private string timeStamp;
        private string fileName;

        private void AddDebugMessage(LogMessage message) {
            string newLogEntryAsJson = JsonUtility.ToJson(message, true);
            string path = GetSavePath();

            if(!Directory.Exists(path)) {
                Directory.CreateDirectory(path);
            }
            PrintToFile(newLogEntryAsJson, path);
        }

        private void PrintToFile(string newLogEntryAsJson, string path) {
            string filePath = $"{path}/{fileName}";
            try {
                File.AppendAllText(filePath, newLogEntryAsJson);
            }
            catch(Exception e) {
                Debug.LogException(e);
            }
        }

        public string GetSavePath() {
            string path = $"{Application.persistentDataPath}{DEFAULT_PATH}";
            if(!string.IsNullOrEmpty(customOutputPath)) {
                path = customOutputPath;
            }
            return path;
        }

        private string GetFileName() {
            StringBuilder sb = new StringBuilder();
            sb.Append(FILENAME);
            if(newFileOnSession) {
                sb.Append(" - ");
                sb.Append(timeStamp);
            }
            sb.Append(FILE_EXTENSION);

            return sb.ToString();
        }

        private void OnEnable() {
            InGameLogger.OnLogRecived += AddDebugMessage;
        }

        private void OnDisable() {
            InGameLogger.OnLogRecived -= AddDebugMessage;
        }

        public void SetOutputFolder(string path) {
            customOutputPath = path;
        }

        private void Awake() {
            timeStamp = DateTime.Now.ToString();
            timeStamp = timeStamp.Replace(':', '.');
            fileName = GetFileName();
        }

#if UNITY_EDITOR
        public string SelectOutputFolder() {
            string path = EditorUtility.OpenFolderPanel("Select save folder", Application.dataPath, "DebugLogOutput");
            
            return path;
        }
       
        private void OnValidate() {
            customOutputPath = EditorPrefs.GetString("InGameLoggerPath");    
        }
#endif
    }
}
