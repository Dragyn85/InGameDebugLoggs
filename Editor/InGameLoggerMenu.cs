#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using UnityEngine.EventSystems;

public class InGameLoggerMenu : MonoBehaviour {
    private const string PREFAB_PATH = "Packages/com.dragyngames.debug/Prefabs/InGameLogger.prefab";
    private const string ADD_EVENT_SYSTEM_QUESTION = "There is no Event System in the current scene, would you like to add one?";

    [MenuItem("InGameLogger/Add prefab")]
    public static void AddInGameLoggerPrefabToScene() {
        bool noInGameLoggerPresent = FindObjectOfType<InGameLogger>() == null;

        if(noInGameLoggerPresent) {
            AddInGameLogger();

            if(ShouldAddEventSystem()) {
                AddEventSystem();
            }
        }
    }

    private static void AddInGameLogger() {
        GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(PREFAB_PATH);
        GameObject sceneObject = Instantiate(prefab);

        sceneObject.name = "In Game Logger";
    }

    private static bool ShouldAddEventSystem() {
        if(FindObjectOfType<EventSystem>() != null) {
            return false;
        }
        return EditorUtility.DisplayDialog("Event System missing", ADD_EVENT_SYSTEM_QUESTION, "Yes", "No");
    }

    private static void AddEventSystem() {
        GameObject EventSystem = new GameObject("Event System");
        EventSystem.AddComponent<EventSystem>();
        EventSystem.AddComponent<StandaloneInputModule>();
    }
}
#endif
