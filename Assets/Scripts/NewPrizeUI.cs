using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
public class NewPrizeUI : MonoBehaviour
{
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
    public void Activate()
    {
        newPrizeUI.enabled = true;

    }

    public void Close()
    {
        newPrizeUI.enabled = false;
    }

}
