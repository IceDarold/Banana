using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePrize : MonoBehaviour
{
    [SerializeField] private Canvas mainUI;
    [SerializeField] private Canvas timePrizeUI;
    public void GetBack()
    {
        mainUI.enabled = true;
        timePrizeUI.enabled = false;
    }
}
