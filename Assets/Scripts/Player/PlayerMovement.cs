using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameModeSwitcher _gameModeSwitcher;
    [SerializeField] private TouchInput _touchInput;
    [SerializeField] private float _speed;
    [SerializeField] private float _leftRestriction, _rightRestriction;

    private Player _player;
    private float _horizontalMove;
    private bool _playerAlive;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void OnEnable()
    {
        _gameModeSwitcher.GameStarted += OnGameStarted;
        _touchInput.Touched += OnTouched;
        _player.Died += OnDied;
    }

    private void OnDisable()
    {
        _gameModeSwitcher.GameStarted -= OnGameStarted;
        _touchInput.Touched -= OnTouched;
        _player.Died -= OnDied;
    }

    private void FixedUpdate()
    { 
        transform.position = new Vector3(transform.localPosition.x, transform.localPosition.y, _horizontalMove * _speed * Time.deltaTime);
    }

    private void OnGameStarted()
    {
        _playerAlive = true;
    }

    private void OnTouched(float value)
    {
        if(_playerAlive == true && CanMove(value) == true)
            _horizontalMove -= value;
    }

    private void OnDied()
    {
        _playerAlive = false;
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
