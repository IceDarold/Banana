using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class TimersController : MonoBehaviour
    {
        [SerializeField] private PrizeButtonsController prizeButtonsController;

        private Dictionary<RarityType, PrizeTimer> _timers;


        private void Awake()
        {
            _timers = new Dictionary<RarityType, PrizeTimer> ();
            InitTimers();

            prizeButtonsController.OnGetPrizeEnd += StartTimer;
        }

        private void OnDisable()
        {
            OffTimers();

            prizeButtonsController.OnGetPrizeEnd -= StartTimer;
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
            string time = _timers[type].GetTime();

            prizeButtonsController.UpdateData(time,type);

        }


        private void OnTimerEnd(RarityType type)
        {
            prizeButtonsController.UpdateData("Stopped", type);
        }

        private void StartTimer(RarityType type)
        {
            _timers[type].SetTime(UnityEngine.Random.value * 100f);
        }

        private void StartTimers()
        {
            foreach (var _timer in _timers)
            {
                _timer.Value.SetTime(UnityEngine.Random.value * 100f);
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