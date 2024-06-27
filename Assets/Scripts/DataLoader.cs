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


    private void Load()
    {
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
            if (Enum.TryParse<RarityType>(name[name.Length - 1], false, out type))
            {
                
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


                dataList.Add(new ItemData(type, chance, garant));
            }

        }
    }


}


public struct ItemData
{
    public RarityType RarityType;
    public float Chance;
    public int GarantReceive;

    public ItemData(RarityType rarityType, float chance, int garantReceive)
    {
        RarityType = rarityType;
        Chance = chance;
        GarantReceive = garantReceive;


    }
}
