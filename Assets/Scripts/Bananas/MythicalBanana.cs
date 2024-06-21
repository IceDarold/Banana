using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New mythical banana", menuName = "Banana/Mythical")]
public class MythicalBanana : Banana
{
    public MythicalBanana()
    {
        chance = 0.000640;
    }
}
