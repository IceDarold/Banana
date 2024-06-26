using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
public class NewPrizeUI : MonoBehaviour
{


    public Action OnScreenOff;

    [SerializeField] private Button continueButton;
    private Canvas newPrizeUI;


    private void Awake()
    {
        newPrizeUI = GetComponent<Canvas>();

        continueButton.onClick.AddListener(Close);
    }

    private void OnDisable()
    {
        continueButton.onClick.RemoveAllListeners();
    }
    public void Activate(RarityType type)
    {
        newPrizeUI.enabled = true;

    }

    public void Close()
    {
        newPrizeUI.enabled = false;

        OnScreenOff?.Invoke();

    }

}
