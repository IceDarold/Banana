using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trade : MonoBehaviour
{
    [SerializeField]
    private ScrollRect ScrollRect;
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
        FierstFillingScrollRect();
    }
    public void GetBack()
    {
        mainUI.enabled = true;
        tradeUI.enabled = false;
    }

    private void FierstFillingScrollRect()
    {
        for (int i = 0; i < 30; i++)
        {
            LotGenerator.CreateLot(Banana);
        }

        //Scoll up ScrollRect
        ScrollRect.verticalNormalizedPosition = 1f;
    }
}
