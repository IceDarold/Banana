using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New super rare banana", menuName = "Banana/Super rare")]
public class SuperRareBanana : Banana
{
    public SuperRareBanana()
    {
        chance = 0.016000;
    }
}
