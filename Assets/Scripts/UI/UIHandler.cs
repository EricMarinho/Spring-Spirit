using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private GameObject interactionUI;
    [SerializeField] private TMP_Text interactionText;

    public static UIHandler instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void OnEnable()
    {
        ShowInteractionText();
    }

    public void ShowInteractionUI() {

        interactionUI.SetActive(true);
    }

    public void HideInteractionUI()
    {
        interactionUI.SetActive(false);
    }

    public void ShowInteractionText()
    {
        interactionText.SetText("Press E to INTERACT");
    }

    public void ShowStopInteractionText()
    {
        interactionText.SetText("Press E to RELEASE");
    }

}
