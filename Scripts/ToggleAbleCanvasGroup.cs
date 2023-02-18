using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class ToggleAbleCanvasGroup : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasGroup;

    private bool isActive;

    public bool IsActive => isActive;

    private void OnValidate() {
        canvasGroup = GetComponent<CanvasGroup>();
    }
    
    public void ToggleCanvas() {
        if(canvasGroup != null) {
            isActive = !isActive;
            canvasGroup.alpha = isActive? 1 : 0;
            canvasGroup.blocksRaycasts = isActive;
            canvasGroup.interactable = isActive;
        }
    }
}
