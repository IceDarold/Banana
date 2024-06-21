using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.Mathematics;
using UnityEngine;


public class PermanentAwards : MonoBehaviour
{
    [SerializeField]
    private EpicBanana[] RareBananas;
    [SerializeField]
    private EpicBanana[] SuperRareBananas;
    [SerializeField]
    private EpicBanana[] EpicBananas;
    [SerializeField]
    private EpicBanana[] MythicalBananas;
    [SerializeField]
    private EpicBanana[] LegendaryBananas;

    private Banana[][] Bananas;
    int indicator = 0;

    [SerializeField]
    private StreamReader BananaGarant;
    private int ClicksForGarant = 0;
    private void Awake()
    {
        if(BananaGarant != null) 
        {
            BananaGarant.ReadLine();   // первая строчка заглавие, а не данные
            string s = BananaGarant.ReadLine();
            if(s != null)
            {
                ClicksForGarant = Int32.Parse(s.Split(',')[1]);
            }
        }
        Bananas = new Banana[][] { RareBananas, SuperRareBananas, EpicBananas, MythicalBananas, LegendaryBananas };
    }

    public void CheckCliksForGarant(int clicksForGarant)
    {
        if(clicksForGarant == ClicksForGarant)
        {
            int rand = UnityEngine.Random.Range(0, Bananas[indicator].Length);
            Inventory.AddNewItem(Bananas[indicator][rand]);
            indicator++;

            if(BananaGarant != null)
            {
                string s = BananaGarant.ReadLine();
                if (s != null)
                {
                    ClicksForGarant = Int32.Parse(s.Split(',')[1]);
                }
                else
                {
                    ClicksForGarant = 0;
                }
            }
        }
    }

}