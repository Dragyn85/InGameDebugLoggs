using UnityEngine;

namespace DragynGames.InGameLogger {

    public class debugSpammer : MonoBehaviour {
        int counter;
        private void Awake() {
            InvokeRepeating("ShowDebugMessage", 1, 1);
        }

        void ShowDebugMessage() {
            if(counter % 3 == 0) {
                Debug.Log("Normal Log " + counter);
            }
            else if((counter + 1) % 3 == 0) {
                Debug.LogWarning("You got a warning! " + counter);
            }
            else if((counter + 2) % 3 == 0) {
                Debug.LogError("ERROR! " + counter);
            }

            counter++;
        }
    }
}
