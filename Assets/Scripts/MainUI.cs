using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI number;
    public void BananaPress()
    {
        int count = Convert.ToInt32(number.text);
        number.text = Convert.ToString(count + 1);
    }
}
