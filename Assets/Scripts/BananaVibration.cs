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

    [SerializeField] private InputController inputController;
    private Rigidbody _rb;


    private Vector3 _startPosition;
    private Quaternion _startRotation;
    private VibrationState _state = VibrationState.Default;
    private float _elapsedTime = 0f;
    

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();

        _startPosition = transform.position;
        _startRotation = transform.rotation;

        inputController.OnClickBanana += OnClick;


    }

    private void OnDisable()
    {
        inputController.OnClickBanana -= OnClick;
    }


    private void Update()
    {
        if(_state == VibrationState.Return)
        {
            Vector3 currentPosition = transform.position;
            Quaternion currentRotation = transform.rotation;

            transform.position = Vector3.Lerp(currentPosition, _startPosition, _elapsedTime / returnTime);
            transform.rotation = Quaternion.Lerp(currentRotation, _startRotation, _elapsedTime / returnTime);
            _elapsedTime += Time.deltaTime;

            if(returnTime - _elapsedTime < 0.001f) 
            {
                _state = VibrationState.Default;
                transform.position = _startPosition;
                transform.rotation = _startRotation;
                _elapsedTime = 0f;
            }
        }
    }

    private void OnClick()
    {
        if(_state != VibrationState.AddingForce)
        {
            StartCoroutine(AddVibration(inputController.ClickPosition));
        }
    }
    

    private IEnumerator AddVibration(Vector3 pos)
    {
        _rb.AddForceAtPosition(new Vector3(0, 0, 1) * force, pos,ForceMode.Impulse);
        _state = VibrationState.AddingForce;
        _elapsedTime = 0f;

        yield return new WaitForSeconds(stopTime);

        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;
        _state = VibrationState.Return;

        yield break;
    }


    private enum VibrationState
    {
        Default,
        AddingForce,
        Return
    }
}
