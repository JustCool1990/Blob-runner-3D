using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private TouchInput _touchInput;
    [SerializeField] private float _speed;
    [SerializeField] private float _leftRestriction, _rightRestriction;

    private float _horizontalMove;

    private void OnEnable()
    {
        _touchInput.Touched += OnTouched;
    }

    private void OnDisable()
    {
        _touchInput.Touched -= OnTouched;
    }

    private void FixedUpdate()
    { 
        transform.position = new Vector3(transform.localPosition.x, transform.localPosition.y, _horizontalMove * _speed * Time.deltaTime);
    }

    private void OnTouched(float value)
    {
        if(CanMove(value) == true)
            _horizontalMove -= value;
    }

    private bool CanMove(float value)
    {
        if (value > 0 && transform.position.z > _leftRestriction)
            return true;
        else if (value < 0 && transform.position.z < _rightRestriction)
            return true;
        else
            return false;
    }
}
