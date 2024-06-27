using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
public class NewPrizeUI : MonoBehaviour
{


    public Action OnScreenOff;

    [SerializeField] private Button continueButton;
    [SerializeField] private TextMeshProUGUI itemText;

    private Canvas newPrizeUI;

    private const string NEW_ITEM_INTRO = "Вы получили ";

    private void Awake()
    {
        newPrizeUI = GetComponent<Canvas>();

        continueButton.onClick.AddListener(Close);
    }

    private void OnDisable()
    {
        continueButton.onClick.RemoveAllListeners();
    }
    public void Activate(string item)
    {
        newPrizeUI.enabled = true;

        itemText.text = NEW_ITEM_INTRO + item;

    }

    public void Close()
    {
        newPrizeUI.enabled = false;

        OnScreenOff?.Invoke();

    }

}
