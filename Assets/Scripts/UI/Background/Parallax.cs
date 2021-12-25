using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class Parallax : MonoBehaviour
{
    [SerializeField] private GameModeSwitcher _gameModeSwitcher;
    //[SerializeField] private DistanceCounter _distanceCounter;
    [SerializeField] private float _speed;
    //[SerializeField] private float _standartAccelerationCoefficient = 1;

    [SerializeField] private bool _OtherSide = false;
    [SerializeField] private ScrollDirection _scrollDirection;
    [SerializeField] private bool _horizontalScroll = false;
    [SerializeField] private bool _verticallScroll = false;


    //private float _lastAccelerationCoefficient;
    private RawImage _image;
    private float _standartSpeed;
    private float _imagePositionY = 0;
    private float _imagePositionX = 0;
    //private bool _scroll = false;
    /*private float _lowerScrollLimiter = 0.15f;
    private float _upperScrollLimiter = -0.15f;*/
    private bool _resetUVRectY => _imagePositionY <= -1 || _imagePositionY >= 1;
    private bool _resetUVRectX => _imagePositionX <= -1 || _imagePositionX >= 1;
    private bool _scroll => _horizontalScroll == true || _verticallScroll == true;

    private void Awake()
    {
        _image = GetComponent<RawImage>();
        _standartSpeed = _speed;
        //_lastAccelerationCoefficient = _standartAccelerationCoefficient;
        //StopSpeed();
    }

    private void OnEnable()
    {
        _gameModeSwitcher.GameStarted += OnGameStarted;
        /*_gameModeSwitcher.GameOver += OnGameOver;
        _gameModeSwitcher.ReturningStartScreen += OnReturningStartScreen;
        _distanceCounter.SpeedIncreased += OnSpeedIncreased;*/
    }

    private void OnDisable()
    {
        _gameModeSwitcher.GameStarted -= OnGameStarted;
        /*_gameModeSwitcher.GameOver -= OnGameOver;
        _gameModeSwitcher.ReturningStartScreen -= OnReturningStartScreen;
        _distanceCounter.SpeedIncreased -= OnSpeedIncreased;*/
    }

    private void FixedUpdate()
    {
        if (_scroll == true)
        {
            ScrollBackground();
        }
    }

    private void ScrollBackground()
    {
        if(_horizontalScroll == true)
            _imagePositionX -= _speed * Time.deltaTime * (_OtherSide == true? -1: 1);

        if(_verticallScroll == true)
            _imagePositionY -= _speed * Time.deltaTime * (_OtherSide == true? -1: 1);

        if (_resetUVRectY == true)
            _imagePositionY = 0;

        if (_resetUVRectX == true)
            _imagePositionX = 0;

        _image.uvRect = new Rect(_imagePositionX, _imagePositionY, _image.uvRect.width, _image.uvRect.height);
    }

    private void OnGameStarted()
    {
        _verticallScroll = true;
    }
    
    /*private void OnGameOver()
    {
        StopSpeed();
    }
    private void OnReturningStartScreen()
    {
        OnGameOver();
    }*/

    /*private void OnSpeedIncreased(float accelerationCoefficient)
    {
        _lastAccelerationCoefficient += accelerationCoefficient;
    }*/

    private void StopSpeed()
    {
        _speed = 0;
    }

    private void ResetSpeed()
    {
        _speed = _standartSpeed;
        //_lastAccelerationCoefficient = _standartAccelerationCoefficient;
    }
}

public enum ScrollDirection
{
    Stay,
    Up,
    Down,
    Left,
    Right
}
