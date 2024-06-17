using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trade : MonoBehaviour
{
    [SerializeField] private Canvas mainUI;
    [SerializeField] private Canvas tradeUI;
    public void GetBack()
    {
        mainUI.enabled = true;
        tradeUI.enabled = false;
    }
}
