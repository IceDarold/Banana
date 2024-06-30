using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Lot : MonoBehaviour
{
    public static TextMeshProUGUI BalanceText;
    public static GameObject BuyButtons;
    public static GameObject NotEnoughMoney;

    public GameObject ThisLot;
    public float Price;
    public Banana Banana;

    public void ClickOnLot()
    {
        string balance = BalanceText.text;
        if (float.Parse(balance) >= Price)
        {
            BuyButtons.SetActive(true);

            BuyButton buyButton = BuyButtons.GetComponent<BuyButton>();
            buyButton.Banana = Banana;
            buyButton.Price = Price;
            buyButton.ThisLot = ThisLot;
        }
        else
        {
            NotEnoughMoney.SetActive(true);
        }
    }
}