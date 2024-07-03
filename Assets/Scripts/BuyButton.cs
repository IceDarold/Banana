using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuyButton : MonoBehaviour
{
    public Action BuyLot;
    public Action OffThisLot;

    public void BuyAndOffLot()
    {
        BuyLot();
        OffThisLot();
    }
}
