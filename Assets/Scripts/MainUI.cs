using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI number;
    [SerializeField] private AudioSource soundEffect;
    [SerializeField] private Canvas timePrizeUI;
    [SerializeField] private Canvas tradeUI;
    [SerializeField] private Canvas mainUI;
    [SerializeField] private Canvas openCaseUI;
    private AudioClip[] soundClips;
    public List<string[]> chances;
    private float case_rarity;

    public void BananaPress()
    {
        int count = Convert.ToInt32(number.text);
        number.text = Convert.ToString(count + 1);
        PlaySound();
        CheckForCase();
    }
    private void CheckForCase()
    {
        float random_value = UnityEngine.Random.value;

        if (random_value <= case_rarity)
        {
            Debug.Log("Dropping case");
            OpenCase();
        }
    }

    void Start()
    {
        soundEffect = GetComponent<AudioSource>();
        if (soundEffect == null)
        {
            soundEffect = gameObject.AddComponent<AudioSource>();
        }
        soundClips = Resources.LoadAll<AudioClip>("Sounds/Hits");
        TextAsset csvFile = Resources.Load<TextAsset>("Data/chances");
        StringReader reader = new StringReader(csvFile.text);
        List<string[]> chances = new List<string[]>();
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            string[] fields = line.Split(',');
            chances.Add(fields);
        }
        CultureInfo ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();
        ci.NumberFormat.CurrencyDecimalSeparator = ".";
        case_rarity = float.Parse(chances[6][1], NumberStyles.Any, ci);
        Debug.Log("case_rarity: " + case_rarity);
    }

    private void PlaySound()
    {
        if (soundEffect != null && soundClips.Length > 0)
        {
            AudioClip randomClip = soundClips[UnityEngine.Random.Range(0, soundClips.Length)];
            soundEffect.clip = randomClip;
            soundEffect.Play();
        }
    }
    public void TimePrize()
    {
        mainUI.enabled = false;
        timePrizeUI.enabled = true;
    }
    public void Trade()
    {
        mainUI.enabled = false;
        tradeUI.enabled = true;
    }
    public void OpenCase()
    {
        mainUI.enabled = false;
        openCaseUI.enabled = true;
    }
}
