using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Inventory : MonoBehaviour
{
    private static Dictionary<string, int> _itemList;

    private void Awake()
    {
        _itemList = new Dictionary<string, int>();
    }
    public static void AddNewItem(string banana)
    {
        if (_itemList.ContainsKey(banana))
        {
            _itemList[banana] += 1;
        }
        else
        {
            _itemList[banana] = 1;
        }
    }
}
