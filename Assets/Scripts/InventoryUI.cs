using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField] private Button previousPage;
        [SerializeField] private Button nextPage;
        [SerializeField] private TextMeshProUGUI pageText;

        private int currentPage;
        private int maxPage;

        private void Awake()
        {
            Activate();

            previousPage.onClick.AddListener(PreviousPage);
            nextPage.onClick.AddListener(NextPage);
        }

        private void OnDisable()
        {
            previousPage.onClick.RemoveListener(PreviousPage);
            nextPage.onClick.RemoveListener(NextPage);
        }

        public void Activate()
        {

        }


        private void PreviousPage()
        {

        }


        private void NextPage()
        {
            
        }
        
    }
}