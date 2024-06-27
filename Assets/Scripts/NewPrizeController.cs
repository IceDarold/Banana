using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class NewPrizeController : MonoBehaviour
    {

        public Action<RarityType> OnGetPrizeEnd;

        [SerializeField] private NewPrizeUI newPrizeUI;
        [SerializeField] private PrizeButtonsController prizeButtonsController;


        private RarityType _currentPrizeRarity;

        private void Awake()
        {
            prizeButtonsController.OnGetPrize += OnGetPrize;
            newPrizeUI.OnScreenOff += GetPrizeEnd;
        }

        private void OnDisable()
        {
            prizeButtonsController.OnGetPrize -= OnGetPrize;
            newPrizeUI.OnScreenOff -= GetPrizeEnd;
        }




        private void OnGetPrize(RarityType type)
        {
            string example = "{какой-то банан}";
            newPrizeUI.Activate(example);
            _currentPrizeRarity = type;
        }

        private void GetPrizeEnd()
        {
            OnGetPrizeEnd?.Invoke(_currentPrizeRarity);
        }

    }
}