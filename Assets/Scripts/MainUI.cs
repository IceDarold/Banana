using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI number;
    [SerializeField] private AudioSource soundEffect;
    [SerializeField] private Canvas timePrizeUI;
    [SerializeField] private Canvas tradeUI;
    [SerializeField] private Canvas mainUI;
    private AudioClip[] soundClips;

    [SerializeField]
    PermanentAwards PA;  

    public void BananaPress()
    {
        int count = Convert.ToInt32(number.text);
        number.text = Convert.ToString(count + 1);
        PlaySound();

        PA.CheckCliksForGarant(count + 1);
    }

    void Start()
    {
        soundEffect = GetComponent<AudioSource>();
        if (soundEffect == null)
        {
            soundEffect = gameObject.AddComponent<AudioSource>();
        }
        soundClips = Resources.LoadAll<AudioClip>("Sounds/Hits");
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
}