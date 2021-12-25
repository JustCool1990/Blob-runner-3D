using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(TouchInput))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _leftRestriction, _rightRestriction;


    private TouchInput _touchInput;
    private Rigidbody _rigidbody;
    private float _horizontalMove;
    private bool OnPlatform => transform.localPosition.z > _leftRestriction && transform.localPosition.z < _rightRestriction;

    private void Awake()
    {
        _touchInput = GetComponent<TouchInput>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _touchInput.Touched += OnTouched;
        _touchInput.Untouched += OnUntouched;
    }

    private void OnDisable()
    {
        _touchInput.Touched -= OnTouched;
        _touchInput.Untouched -= OnUntouched;
    }

    private void FixedUpdate()
    {
        //_rigidbody.velocity = new Vector3(_rigidbody.velocity.x, _rigidbody.velocity.y, -_horizontalMove * _speed);
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

    private void OnUntouched()
    {
        //_horizontalMove = 0;
    }
}
