using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BananaVibration : MonoBehaviour
{
    [SerializeField] private float force;
    [SerializeField] private float stopTime = 0.2f;
    [SerializeField] private float returnTime = 0.2f;

    private Rigidbody _rb;


    private Vector3 _startPosition;
    private Quaternion _startRotation;

    private bool _isDirty;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();

        _startPosition = transform.position;
        _startRotation = transform.rotation;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                if(hit.transform.GetComponent<BananaVibration>() != null)
                {
                    StartCoroutine(AddVibration(hit));
                    
                }
            }
        }


    }

    private IEnumerator AddVibration(RaycastHit hit)
    {
        _rb.AddForceAtPosition(new Vector3(0, 0, 1) * force, hit.point,ForceMode.Impulse);
        yield return new WaitForSeconds(stopTime);
        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;

        Vector3 currentPosition = transform.position;
        Quaternion currentRotation = transform.rotation;

        float elapsedTime = 0f;

        while(elapsedTime < returnTime) 
        { 
            transform.position = Vector3.Lerp(currentPosition, _startPosition, elapsedTime/returnTime);
            transform.rotation = Quaternion.Lerp(currentRotation,_startRotation, elapsedTime/returnTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = _startPosition;
        transform.rotation = _startRotation;

        yield break;
    }


    
}
