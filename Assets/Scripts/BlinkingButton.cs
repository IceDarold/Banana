using System.Collections;
using TMPro;
using UnityEngine;

namespace Assets.Scripts
{
    public class BlinkingButton : MonoBehaviour
    {

        [SerializeField] private float blinkingTime;


        private TextMeshProUGUI _text;

        private bool isIncreasing = false;
        private float _currentTime= 0f;

        private void Awake()
        {
            _text = GetComponentInChildren<TextMeshProUGUI>();
        }


        private void Update()
        {
            float alpha = 0;
            _currentTime += Time.deltaTime;

            if (!isIncreasing)
            {
                alpha = Mathf.Lerp(1, 0, _currentTime / blinkingTime);

                if(alpha <= 0.1)
                {
                    isIncreasing = true;
                    _currentTime = 0f;
                }
            }
            else
            {
                alpha = Mathf.Lerp(0,1, _currentTime / blinkingTime);

                if (alpha >= 0.9)
                {
                    isIncreasing = false;
                    _currentTime = 0f;
                }
            }



            _text.faceColor = new Color(0, 0, 0, alpha);
             
        }


    }
}