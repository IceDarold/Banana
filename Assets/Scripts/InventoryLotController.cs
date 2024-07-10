using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.PackageManager;
using UnityEngine;

namespace Assets.Scripts
{
    public class InventoryLotController : MonoBehaviour
    {
        [SerializeField] private Vector2Int tableSize;
        [SerializeField] private GameObject lotPrefab;

        private List<InventoryLot> _activeLots = new List<InventoryLot>();
        private RectTransform _rectTransform;
        private Vector2 _size;


        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _size = _rectTransform.rect.size;
            
        }



        [ContextMenu("Update Lots")]
        public void UpdateLots()
        {
            int page = 1;
            bool shouldChangeRect = false;

            if(tableSize.x * tableSize.y != _activeLots.Count)
            {
                ChangeLotsCount();
                shouldChangeRect = true;
                
            }

            if(_rectTransform.rect.size != _size)
            {
                shouldChangeRect = true;
                _size = _rectTransform.rect.size;
            }

            var data = Inventory.GetData((page - 1) * tableSize.x * tableSize.y, page * tableSize.x * tableSize.y - 1);

            int i = 0;
            Debug.Log(data.Count());
            foreach(var item in data)
            {
                if(shouldChangeRect)
                {
                    Debug.Log(".");
                    _activeLots[i].UpdateData(null, 0, GetLotRect(i));
                }
                else
                {
                    _activeLots[i].UpdateData(null, 0);
                }
                
                i++;              
            }

        }


        private void ChangeLotsCount()
        {
            if(_activeLots.Count > tableSize.x * tableSize.y)
            {
                _activeLots.GetRange(tableSize.x * tableSize.y, _activeLots.Count - tableSize.x * tableSize.y).ForEach(item => Destroy(item.gameObject));
                _activeLots = _activeLots.GetRange(0, tableSize.x * tableSize.y);
                
            }
            else
            {
                int delta = tableSize.x * tableSize.y - _activeLots.Count;
                for (int i = 0; i < delta; i++)
                {
                    GameObject lotObj = Instantiate(lotPrefab,transform);
                    _activeLots.Add(lotObj.GetComponent<InventoryLot>());
                    
                }
            }
        }

        private Rect GetLotRect(int index)
        {
            Vector2Int tablePos = new Vector2Int(index % tableSize.x, index / tableSize.x);
            Vector2 size = _size / tableSize;
            Vector2 pos = (tablePos + new Vector2(0.5f, 0.5f)) * size - _rectTransform.rect.size/2;

            Debug.Log(size.ToString() + " " + pos.ToString());
            return new Rect(pos, size);

        }


        
    }
}