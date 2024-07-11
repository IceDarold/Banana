using System.Collections;
using TMPro;
using UnityEngine;

namespace Assets.Scripts
{
    public class InventoryLot : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI countText;
        private RectTransform _rectTransform;
        private RectTransform[] _children;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>(); 

            _children = GetComponentsInChildren<RectTransform>();
        }

        public void UpdateData(Sprite sprite, int count) 
        {
            Debug.Log(count);
            countText.text = count.ToString();
        }

        public void UpdateData(Sprite sprite,int count, Rect rect)
        {
            UpdateData(sprite, count);

            _rectTransform.localPosition = rect.position;


            float delta = rect.height / _rectTransform.rect.height;
            for (int i = 0; i < _children.Length; i++) 
            {
                _children[i].localScale = _children[i].localScale * delta;
            }

            _rectTransform.sizeDelta = rect.size;
            _rectTransform.localScale = Vector3.one;
        }
    }
}