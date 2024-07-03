using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Trade : MonoBehaviour
{
    [SerializeField] 
    private Canvas mainUI;
    [SerializeField] 
    private Canvas tradeUI;
    [SerializeField]
    public TextMeshProUGUI BalanceText;
    [SerializeField]
    public float Balance = 0;

    private void Awake()
    {
        BalanceText.text = Convert.ToString(Balance);
    }
    public void GetBack()
    {
        mainUI.enabled = true;
        tradeUI.enabled = false;
    }
}
