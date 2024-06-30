using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuyButton : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI BalanceText;
    public GameObject ThisLot;
    public Banana Banana;
    public float Price;

    public void BuyLot()
    {
        float balance = float.Parse(BalanceText.text);
        balance -= Price;
        BalanceText.text = Convert.ToString(balance);

        Inventory.AddNewItem(Banana);
    }
    public void OffThisLot()
    {
        ThisLot.SetActive(false);
    }
}
