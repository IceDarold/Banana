using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.Mathematics;
using UnityEngine;


public class PermanentAwards : MonoBehaviour
{
    private StreamReader _bananaChanceReader;

    int _clicksForGarant = -1;
    int _indicator = 0;

    private void Start()
    {
        LoadbananaChanceReader();

        InitRareClicksForGarant();
    }

    public void CheckCliksForGarant(int clicksForGarant)
    {
        if (clicksForGarant == _clicksForGarant)
        {
            if (_indicator >= AllBananas.Bananas.Length)
            {
                _clicksForGarant = -1;
                return;
            }

            int rand = UnityEngine.Random.Range(0, AllBananas.Bananas[_indicator].Length);
            Inventory.AddNewItem(AllBananas.Bananas[_indicator][rand]);
            _indicator++;

            if (_bananaChanceReader != null)
            {
                string s = _bananaChanceReader.ReadLine();
                if (s != null)
                {
                    _clicksForGarant = Int32.Parse(s.Split(',')[2]);
                }
                else
                {
                    _clicksForGarant = -1;
                }
            }
        }
    }

    private void LoadbananaChanceReader()
    {
        TextAsset textAsset = Resources.Load<TextAsset>("Data/chances");

        if (textAsset != null)
        {
            // Using StreamReader to work with a file
            _bananaChanceReader = new StreamReader(new MemoryStream(textAsset.bytes));
        }
    }

    private void InitRareClicksForGarant()
    {
        if (_bananaChanceReader != null)
        {
            _bananaChanceReader.ReadLine();   // the first line is the title, not the data
            string s = _bananaChanceReader.ReadLine();
            if (s != null)
            {
                _clicksForGarant = Int32.Parse(s.Split(',')[2]);
            }
        }
    }
}
