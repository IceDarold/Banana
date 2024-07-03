using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Lot : MonoBehaviour
{
    public GameObject ThisLot;
    public Banana Banana;
    public float Price;

    public void ClickOnLot()
    {
        LotController.ClickOnLot(ThisLot, Banana, Price);
    }
}