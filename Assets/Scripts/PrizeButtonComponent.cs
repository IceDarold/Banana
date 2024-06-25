using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    [RequireComponent (typeof(Button))]
    public class PrizeButtonComponent : MonoBehaviour
    {
        public Action<RarityType> OnGetPrize;


        [SerializeField] private RarityType rarityType;
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private Button button;


        private const string INTRO_SHOW_TIME = "До получения награды осталось: ";
        private const string GET_PRIZE = "<b>Забрать подарок!</b>";


        private void Awake()
        {
            button = GetComponent<Button>();
            button.interactable = false;

            button.onClick.AddListener(() =>  OnGetPrize.Invoke(rarityType));
        }

        private void OnDisable()
        {
            button.onClick.RemoveAllListeners();
        }


        public RarityType GetRarityType()
        {
            return rarityType;
        }


        public void UpdateTime(string time)
        {
            text.text = INTRO_SHOW_TIME + "<b>" + time + "</b>";
        }

        public void SetToGetPrize()
        {
            button.interactable = true;
            text.text = GET_PRIZE;
            
        }

        
       
    }
}