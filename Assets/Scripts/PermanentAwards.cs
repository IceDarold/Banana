using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.Mathematics;
using UnityEngine;


public class PermanentAwards : MonoBehaviour
{
    [SerializeField]
    private RareBanana[] RareBananas;
    [SerializeField]
    private SuperRareBanana[] SuperRareBananas;
    [SerializeField]
    private EpicBanana[] EpicBananas;
    [SerializeField]
    private MythicalBanana[] MythicalBananas;
    [SerializeField]
    private LegendaryBanana[] LegendaryBananas;

    private Banana[][] Bananas;
    int indicator = 0;

    private StreamReader bananaChanceReader;

    private int ClicksForGarant = -1;

    private void Start()
    {
        TextAsset textAsset = Resources.Load<TextAsset>("Data/chances");

        if (textAsset != null)
        {
            // Using StreamReader to work with a file
            bananaChanceReader = new StreamReader(new MemoryStream(textAsset.bytes));
        }

        if (bananaChanceReader != null) 
        {
            bananaChanceReader.ReadLine();   // the first line is the title, not the data
            string s = bananaChanceReader.ReadLine();
            if(s != null)
            {
                ClicksForGarant = Int32.Parse(s.Split(',')[2]);
            }
        }
        Bananas = new Banana[][] { RareBananas, SuperRareBananas, EpicBananas, MythicalBananas, LegendaryBananas };
    }

    public void CheckCliksForGarant(int clicksForGarant)
    {
        if (clicksForGarant == ClicksForGarant)
        {
            if (indicator >= Bananas.Length)
            {
                ClicksForGarant = -1;
                return;
            }

            int rand = UnityEngine.Random.Range(0, Bananas[indicator].Length);
            Inventory.AddNewItem(Bananas[indicator][rand]);
            indicator++;

            if(bananaChanceReader != null)
            {
                string s = bananaChanceReader.ReadLine();
                if (s != null)
                {
                    ClicksForGarant = Int32.Parse(s.Split(',')[2]);
                }
                else
                {
                    ClicksForGarant = -1;
                }
            }
        }
    }

}