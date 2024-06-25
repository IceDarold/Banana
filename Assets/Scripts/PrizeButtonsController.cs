using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class PrizeButtonsController : MonoBehaviour
    {
        [SerializeField] private List<PrizeButtonComponent> prizeButtons;
        [SerializeField] private NewPrizeUI newPrizeUI;


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


        private void OnGetPrize(RarityType type)
        {
            newPrizeUI.Activate();
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