using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Random = UnityEngine.Random;

public class LotGenerator : MonoBehaviour
{
    [SerializeField]
    AnimationCurve curve;
    [SerializeField]
    private GameObject lotPrefab;
    [SerializeField]
    private Transform parentTransform;


    private static List<string> _prefixes = new List<string> { "Dark", "Light", "Fire", "Ice", "Shadow", "Thunder", "Storm", "Silver", "Golden", "Mighty" };
    private static List<string> _suffixes = new List<string> { "Warrior", "Mage", "Rogue", "Hunter", "Knight", "Lord", "Master", "Sage", "Seeker", "Guardian" };
    private static List<string> _middleParts = new List<string> { "Blade", "Strike", "Flame", "Frost", "Wing", "Heart", "Soul", "Moon", "Star", "Shadow" };


    public void CreateLot(Sprite sprite, string bananaName, int minPriñe, int maxPrice)
    {
        GameObject newLot = Instantiate(lotPrefab, parentTransform);


        Image[] image = newLot.GetComponentsInChildren<Image>();
        if (image != null)
        {
            if (sprite != null)
            {
                image[1].sprite = sprite;
            }
        }


        string namePlayer = GenerateNickname();
        string price = CreatePrice(minPriñe, maxPrice);

        TMP_Text[] texts = newLot.GetComponentsInChildren<TMP_Text>();
        if (texts.Length >= 3)
        {
            texts[0].text = bananaName;
            texts[1].text = namePlayer;
            texts[2].text = price;
        }
    }
    private string GenerateNickname()
    {
        string prefix = _prefixes[Random.Range(0, _prefixes.Count)];
        string middle = _middleParts[Random.Range(0, _middleParts.Count)];
        string suffix = _suffixes[Random.Range(0, _suffixes.Count)];

        // 50% chance to use midle part
        if (Random.Range(0, 2) == 0)
        {
            return prefix + middle + suffix;
        }
        else
        {
            return prefix + suffix;
        }
    }
    private string CreatePrice(int minPrice, int maxPrice)
    {
        float price;
        price = minPrice + (maxPrice - minPrice) * curve.Evaluate(Random.Range(0, 1));
        return String.Format("{0:.00}", price);
    }
}
