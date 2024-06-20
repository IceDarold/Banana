using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class OpenCase : MonoBehaviour
{
    [SerializeField] private Canvas mainUI;
    [SerializeField] private Canvas OpenCaseUI;
    private MainUI mainUIscript;
    private List<string[]> chances;
    private float rare_rarity;
    private float superrare_rarity;
    private float epic_rarity;
    private float legendary_rarity;
    private float mythical_rarity;

    private void Start()
    {
        // Загрузка CSV файла из папки Resources
        TextAsset csvFile = Resources.Load<TextAsset>("Data/chances");
        // Чтение строк из файла
        StringReader reader = new StringReader(csvFile.text);
        List<string[]> chances = new List<string[]>();
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            // Разделение строки на элементы
            string[] fields = line.Split(',');
            chances.Add(fields);
        }
        CultureInfo ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();
        ci.NumberFormat.CurrencyDecimalSeparator = ".";
        rare_rarity = float.Parse(chances[7][1], NumberStyles.Any, ci);
        superrare_rarity = float.Parse(chances[8][1], NumberStyles.Any, ci);
        epic_rarity = float.Parse(chances[9][1], NumberStyles.Any, ci);
        legendary_rarity = float.Parse(chances[10][1], NumberStyles.Any, ci);
        mythical_rarity = float.Parse(chances[11][1], NumberStyles.Any, ci);
    }
    public void CaseOnClick()
    {
        Debug.Log("opening case");
        GiveRandomBanana();
        GetBack();
    }
    private void GetBack()
    {
        mainUI.enabled = true;
        OpenCaseUI.enabled = false;
    }
    private void GiveRandomBanana()
    {
        float random_value = UnityEngine.Random.value;
        if (random_value <= rare_rarity + superrare_rarity + epic_rarity + legendary_rarity + mythical_rarity)
        {
            if (random_value <= superrare_rarity + epic_rarity + legendary_rarity + mythical_rarity)
            {
                if (random_value <= epic_rarity + legendary_rarity + mythical_rarity)
                {
                    if (random_value <= legendary_rarity + mythical_rarity)
                    {
                        if (random_value <= mythical_rarity)
                        {
                            // выдать мифический банан
                            Debug.Log("Giving mythical banana");
                        }
                        else
                        {
                            // выдать легендарный банан
                            Debug.Log("Giving legendary banana");
                        }
                    }
                    else
                    {
                        // выдать эпический банан
                        Debug.Log("Giving epic banana");
                    }
                }
                else
                {
                    // выдать суперредкий банан
                    Debug.Log("Giving superrare banana");
                }
            }
            else
            {
                // выдать редкий банан
                Debug.Log("Giving rare banana");
            }
        }
    }
}
