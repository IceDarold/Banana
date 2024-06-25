using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class TimersController : MonoBehaviour
    {
        private Dictionary<RarityType, PrizeTimer> _timers;


        private void Awake()
        {
            _timers = new Dictionary<RarityType, PrizeTimer> ();
            InitTimers();
        }

        private void OnDisable()
        {
            OffTimers();
        }

        

        private void Start()
        {
            StartTimers();
        }


        private void Update()
        {
            foreach (var timer in _timers)
            {
                if (timer.Value.IsEnd)
                {
                    continue;
                }

                timer.Value.OnUpdate();
            }
        }

        private void OnTimerTick(RarityType type)
        {
            Debug.Log(type.ToString() + " Ticked");
        }


        private void OnTimerEnd(RarityType type)
        {
            Debug.Log(type.ToString() + " End");
        }



        private void StartTimers()
        {
            foreach (var _timer in _timers)
            {
                _timer.Value.SetTime(UnityEngine.Random.value * 10f);
            }
        }

        private void InitTimers()
        {
            Array rarityTypes = Enum.GetValues (typeof(RarityType));

            for (int i = 0; i < rarityTypes.Length; i++)
            {
                RarityType type = (RarityType) rarityTypes.GetValue(i);
                PrizeTimer prizeTimer = new PrizeTimer(type);

                prizeTimer.OnTimerTick += OnTimerTick;
                prizeTimer.OnTimerEnd += OnTimerEnd;


                _timers.TryAdd( type, prizeTimer );

            }
        }

        private void OffTimers()
        {
            foreach( var _timer in _timers)
            {
                _timer.Value.OnTimerTick -= OnTimerTick;
                _timer.Value.OnTimerEnd -= OnTimerEnd;
            }
        }

    }
}