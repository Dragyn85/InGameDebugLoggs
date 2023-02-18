using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenCloseButton : MonoBehaviour
{
    [SerializeField] Image buttonImage;
    [SerializeField] private Sprite openSprite;
    [SerializeField] private Sprite closeSprite;
    [SerializeField] ToggleAbleCanvasGroup toggleAbleCanvasGroup;

    public void UpdateSpriteBasedOnCanvasActive() {
        buttonImage.sprite = toggleAbleCanvasGroup.IsActive ? closeSprite : openSprite;
    }
}
