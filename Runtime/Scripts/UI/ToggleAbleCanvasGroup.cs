using System;
using UnityEngine;

namespace DragynGames.InGameLogger {

    [RequireComponent(typeof(CanvasGroup))]
    public class ToggleAbleCanvasGroup : MonoBehaviour {
        [SerializeField] CanvasGroup canvasGroup;
        [SerializeField] private bool startActive;
        [SerializeField] private KeyCode toggleVisibilityButton = KeyCode.None;

        public Action<bool> OnActivationChanged;

        private bool isVisible;
        private IBlockToggle iBlockToggle;

        public bool IsActive {
            get {
                return isVisible;
            }
        }

        private void Awake() {
            SetVisible(startActive);
            iBlockToggle = GetComponent<IBlockToggle>();
        }

        private void OnValidate() {
            canvasGroup = GetComponent<CanvasGroup>();
        }

        private void Update() {
            if(Input.GetKeyDown(toggleVisibilityButton)) {
                ToggleVisibility();
            }
        }

        public void SetVisible(bool visible) {
            isVisible = visible;
            canvasGroup.alpha = isVisible ? 1 : 0;
            canvasGroup.blocksRaycasts = isVisible;
            canvasGroup.interactable = isVisible;
            OnActivationChanged?.Invoke(isVisible);
        }

        public void ToggleVisibility() {
            
            if(iBlockToggle != null && !iBlockToggle.blockToggle) {
                SetVisible(!IsActive);
            }
        }
    }
    public interface IBlockToggle {
        public bool blockToggle { get; }
    }
}
