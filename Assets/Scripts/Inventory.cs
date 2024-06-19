using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Dictionary<Banana, int> itemList = new Dictionary<Banana, int>();
    public void AddNewItem(Banana banana)
    {
        if (itemList.ContainsKey(banana))
        {
            itemList[banana] += 1;
        }
        else
        {
            itemList[banana] = 0;
        }
    }
}
