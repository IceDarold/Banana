using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New rare banana", menuName = "Banana/Rare")]
public class RareBanana : Banana
{
    public RareBanana()
    {
        chance = 0.080000;
    }
}
