using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New legendary banana", menuName = "Banana/Legendary")]
public class LegendaryBanana : Banana
{
    public LegendaryBanana()
    {
        chance = 0.000260;
    }
}
