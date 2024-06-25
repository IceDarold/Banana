using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class PrizeButtonsController : MonoBehaviour
    {
        [SerializeField] private List<PrizeButtonComponent> prizeButtons;

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

        
        
    }
}