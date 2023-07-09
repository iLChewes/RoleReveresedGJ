using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleStartButton : MonoBehaviour
{
    [SerializeField] private Sprite activeIcon;
    [SerializeField] private Sprite disabledIcon;

    private Image image;
    private Button button;

    private void Awake()
    {
        image = GetComponent<Image>();
        button = GetComponent<Button>();
    }

    public void DisableButton()
    {
        image.sprite = disabledIcon;
        button.enabled = false;
    }

    public void ActivateButton()
    {
        image.sprite = activeIcon;
        button.enabled = true;
    }
}
