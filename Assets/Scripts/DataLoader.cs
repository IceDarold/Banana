using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;
using UnityEngine.Scripting;

public  class DataLoader : MonoBehaviour
{
    public static DataLoader Instance;

    private List<ItemData> dataList = new List<ItemData>();

    private const string PATH = "Data/chances";

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }

        Load();
    }


    public ItemData GetData(ItemType itemType,RarityType rarityType)
    {
        foreach(ItemData item in dataList)
        {
            if(item.ItemType == itemType && item.RarityType == rarityType)
            {
                return item;
            }
        }

        return new ItemData();
    }

    private void Load()
    {
        Debug.LogWarning("Super Rare must be written in one word in table!(else you can have bugs)");
        TextAsset csvFile = Resources.Load<TextAsset>(PATH);
        StringReader reader = new StringReader(csvFile.text);
        CultureInfo ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();
        ci.NumberFormat.CurrencyDecimalSeparator = ".";

        string line;
        while((line = reader.ReadLine()) != null)
        {
            string[] fields = line.Split(',');

            string[] name = fields[0].Split(" ");
            RarityType type;
            ItemType itemType;
            if (Enum.TryParse<RarityType>(name[name.Length - 1], false, out type))
            {
                if(name.Length == 1)
                {
                    itemType = ItemType.Banana;
                }
                else
                {
                    itemType = Enum.Parse<ItemType>(name[0]);
                }

                float chance = float.Parse(fields[1], NumberStyles.Any, ci);

                int garant;
                if (fields[2] != "")
                {
                    garant = int.Parse(fields[2], NumberStyles.Any, ci);
                }
                else
                {
                    garant = -1;
                }


                dataList.Add(new ItemData(itemType,type, chance, garant));
            }

        }
    }


}


public struct ItemData
{
    public ItemType ItemType;
    public RarityType RarityType;
    public float Chance;
    public int GarantReceive;

    public ItemData(ItemType itemType , RarityType rarityType, float chance, int garantReceive)
    {
        ItemType = itemType;
        RarityType = rarityType;
        Chance = chance;
        GarantReceive = garantReceive;


    }
}
