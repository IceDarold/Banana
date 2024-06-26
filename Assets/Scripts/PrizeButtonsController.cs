using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class PrizeButtonsController : MonoBehaviour
    {

        public Action<RarityType> OnGetPrizeEnd;

        [SerializeField] private List<PrizeButtonComponent> prizeButtons;
        [SerializeField] private NewPrizeUI newPrizeUI;

        private bool _isActiveNewPrizeScreen = false;
        private RarityType _currentPrize;
        

        private void Awake()
        {
            AddListeners();

            newPrizeUI.OnScreenOff += () => OnGetPrizeEnd.Invoke(_currentPrize);
        }

        private void OnDisable()
        {
            RemoveListeners();

            newPrizeUI.OnScreenOff -= () => OnGetPrizeEnd.Invoke(_currentPrize );
        }



        public void UpdateData(string time,RarityType type)
        {
              foreach (var button in prizeButtons)
              {
                  if (button.GetRarityType() == type)
                  {
                    if(time == "Stopped")
                    {
                        button.SetToGetPrize();
                    }
                    else
                    {
                        button.UpdateTime(time);
                    }
                      
                  }
              }
        }


        private void OnGetPrize(RarityType type)
        {
            newPrizeUI.Activate(type);
            _isActiveNewPrizeScreen = true;
            _currentPrize = type;
        }




        private void AddListeners()
        {
            foreach(var button in prizeButtons)
            {
                button.OnGetPrize += OnGetPrize;
            }
        }

        private void RemoveListeners()
        {
            foreach (var button in prizeButtons)
            {
                button.OnGetPrize -= OnGetPrize;
            }
        }



    }
}