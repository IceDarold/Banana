using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllBananas : MonoBehaviour
{
    [SerializeField]
    private RareBanana[] rareBananas;
    [SerializeField]
    private SuperRareBanana[] superRareBananas;
    [SerializeField]
    private EpicBanana[] epicBananas;
    [SerializeField]
    private MythicalBanana[] mythicalBananas;
    [SerializeField]
    private LegendaryBanana[] legendaryBananas;

    public static Banana[][] Bananas;

    private void Start()
    {
        Bananas = new Banana[][] { rareBananas, superRareBananas, epicBananas, mythicalBananas, legendaryBananas };
    }
}
