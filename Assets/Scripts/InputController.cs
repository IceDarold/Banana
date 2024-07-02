using System;
using System.Collections;
using UnityEngine;


    public class InputController : MonoBehaviour
    {
        public Action OnClickBanana;
        public Vector3 ClickPosition { get; private set; }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.GetComponent<BananaVibration>() != null)
                    {
                        OnClickBanana?.Invoke();
                        ClickPosition = hit.point;

                    }
                }
            }
        }

    }
