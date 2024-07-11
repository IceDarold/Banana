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
        [SerializeField] private Button onButton;
        [SerializeField] private Button offButton;
        [SerializeField] private InventoryLotController inventoryLotController;

        private int _currentPage;
        private int _maxPage;

        private Canvas _canvas;

        private void Awake()
        {
            _canvas = GetComponent<Canvas>();

            previousPage.onClick.AddListener(PreviousPage);
            nextPage.onClick.AddListener(NextPage);

            onButton.onClick.AddListener(Activate);
            offButton.onClick.AddListener(Disable);
        }

        private void OnDisable()
        {
            previousPage.onClick.RemoveListener(PreviousPage);
            nextPage.onClick.RemoveListener(NextPage);

            onButton.onClick.RemoveListener(Activate);
            offButton.onClick.RemoveListener(Disable);

        }


        public void Activate()
        {
            _canvas.enabled = true;
            _currentPage = 1;
            _maxPage = inventoryLotController.GetPageCount();
            inventoryLotController.UpdateLots(_currentPage);

           UpdatePageText();

            CheckButtons();
        }

        public void Disable()
        {
            _canvas.enabled = false;
        }


        private void PreviousPage()
        {
            _currentPage--;
            UpdatePageText();
            inventoryLotController.UpdateLots(_currentPage);
            CheckButtons();
        }


        private void NextPage()
        {
            _currentPage++;
            UpdatePageText();
            inventoryLotController.UpdateLots(_currentPage);
            CheckButtons();
        }
        

        private void CheckButtons()
        {
            previousPage.interactable =!( _currentPage == 1);
            nextPage.interactable = !(_currentPage ==  _maxPage);
        }

        private void UpdatePageText()
        {
            pageText.text = _currentPage.ToString() + "/" + _maxPage.ToString();
        }
    }
}