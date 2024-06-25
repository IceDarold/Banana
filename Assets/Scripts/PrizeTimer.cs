using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class PrizeTimer 
    {
        public bool IsEnd {  get; private set; } = true;

        private float _remainingTime;

        private readonly RussianWord HOURS = new RussianWord("час", "часа", "часв");
        private readonly RussianWord MINUTES = new RussianWord("минута", "минуты", "минут");
        private readonly RussianWord SECONDS = new RussianWord("секунда", "секунды", "секунд");


        public void SetTime(float remainingTime)
        {
            _remainingTime = remainingTime;
            IsEnd = false;
        }


        public void OnUpdate()
        {
            if (!IsEnd)
            {
                _remainingTime -= Time.deltaTime;

                if (_remainingTime <= 0)
                {
                    IsEnd = true;
                }
            }
        }


        private string ConvertTime()
        {
            string result = "";
            int remainingTimeInt = (int)_remainingTime;

            int hours =  remainingTimeInt / 3600;
            int minutes = (remainingTimeInt % 3600) / 60;
            int seconds = ((remainingTimeInt % 3600) % 60);

            result += hours.ToString() + " " + HOURS.GetRightVersion(hours) + " ";
            result += minutes.ToString() + " " + MINUTES.GetRightVersion(minutes) + " ";
            result += seconds.ToString() + " " + SECONDS.GetRightVersion(seconds);


            return result;
        }
        
    }

    public struct RussianWord
    {
        private readonly string V1;
        private readonly string V2;
        private readonly string V3;

        public RussianWord(string v1, string v2,string v3)
        {
            V1 = v1;
            V2 = v2;
            V3 = v3;
        }


        public string GetRightVersion(int numeral)
        {
            if(numeral == 1)
            {
                return V1;
            }
            else if(numeral > 4)
            {
                return V3;
            }
            else
            {
                return V2;
            }
        }
    }

}