using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class PrizeButtonsController : MonoBehaviour
    {

        public Action<RarityType> OnGetPrize;

        [SerializeField] private List<PrizeButtonComponent> prizeButtons;
        [SerializeField] private NewPrizeUI newPrizeUI;

        private bool _isActiveNewPrizeScreen = false;
        private RarityType _currentPrize;
        

        private void Awake()
        {
            AddListeners();

        }

        private void OnDisable()
        {
            RemoveListeners();

            
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

        private void GetPrize(RarityType type)
        {
            OnGetPrize?.Invoke(type);
        }





        private void AddListeners()
        {
            foreach(var button in prizeButtons)
            {
                button.OnGetPrize += GetPrize;
            }
        }

        private void RemoveListeners()
        {
            foreach (var button in prizeButtons)
            {
                button.OnGetPrize -= GetPrize;
            }
        }



    }
}