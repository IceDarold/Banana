using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class PrizeTimer 
    {
        public bool IsEnd {  get; private set; } = true;

        private float _remainingTime;

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
    }
}