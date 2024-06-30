using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trade : MonoBehaviour
{
    [SerializeField] 
    private LotGenerator LotGenerator;
    [SerializeField]
    private Banana Banana;
    [SerializeField] 
    private Canvas mainUI;
    [SerializeField] 
    private Canvas tradeUI;

    private void Start()
    {
        LotGenerator.CreateLot(Banana.sprite, Banana.bananaName, Banana.minPrice, Banana.maxPrice);
    }
    public void GetBack()
    {
        mainUI.enabled = true;
        tradeUI.enabled = false;
    }
}
