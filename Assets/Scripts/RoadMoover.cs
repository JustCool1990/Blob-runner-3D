using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadMoover : MonoBehaviour
{
    [SerializeField] private GameModeSwitcher _gameModeSwitcher;
    [SerializeField] private Vector3 _moveDirection = new Vector3(-1, 0, 0);
    [SerializeField] private float _movingSpeed = 15;

    private bool _gameStarted = false;

    private void OnEnable()
    {
        _gameModeSwitcher.GameStarted += OnGameStarted;
        _gameModeSwitcher.GameEnded += OnGameEnded;
    }

    private void OnDisable()
    {
        _gameModeSwitcher.GameStarted -= OnGameStarted;
        _gameModeSwitcher.GameEnded -= OnGameEnded;
    }

    private void FixedUpdate()
    {
        if(_gameStarted == true)
            transform.Translate(_moveDirection * _movingSpeed * Time.deltaTime);
    }

    private void OnGameStarted()
    {
        _gameStarted = true;
    }

    private void OnGameEnded()
    {
        _gameStarted = false;
    }
}
