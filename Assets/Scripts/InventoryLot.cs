using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class InventoryLot : MonoBehaviour
    {

        private RectTransform _rectTransform;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>(); 
        }

        public void UpdateData(Sprite sprite, int count) 
        {
            
        }

        public void UpdateData(Sprite sprite,int count, Rect rect)
        {
            UpdateData(sprite, count);
            _rectTransform.localPosition = rect.position;
            _rectTransform.sizeDelta = rect.size;
        }
    }
}