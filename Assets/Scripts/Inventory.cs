using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class Inventory
{
    static public Dictionary<Banana, int> itemList = new Dictionary<Banana, int>();
    static public void AddNewItem(Banana banana)
    {
        if (itemList.ContainsKey(banana))
        {
            itemList[banana] += 1;
        }
        else
        {
            itemList[banana] = 1;
        }
    }
}
