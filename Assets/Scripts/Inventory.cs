using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public  class Inventory : MonoBehaviour
{
    private static Dictionary<string, int> _itemList;

    private void Awake()
    {
        _itemList = new Dictionary<string, int>();
        DebugFillInventory();
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

    public static int GetItemsCount()
    {
        return _itemList.Count;
    }


    public static IEnumerable<KeyValuePair<string,int>> GetData(int start,int stop)
    {
        return _itemList.Skip(start).Take(stop - start + 1);
    }


    private void DebugFillInventory()
    {
        for (int i = 0; i < 15; i++)
        {
            AddNewItem(i.ToString());
        }
    }
}
