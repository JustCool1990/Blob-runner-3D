using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class Parallax : MonoBehaviour
{
    [SerializeField] private GameModeSwitcher _gameModeSwitcher;
    [SerializeField] private float _speed;

    [SerializeField] private bool _OtherSide = false;
    [SerializeField] private bool _horizontalScroll = false;
    [SerializeField] private bool _verticallScroll = false;


    private RawImage _image;
    private float _imagePositionY = 0;
    private float _imagePositionX = 0;

    private bool _resetUVRectY => _imagePositionY <= -1 || _imagePositionY >= 1;
    private bool _resetUVRectX => _imagePositionX <= -1 || _imagePositionX >= 1;
    private bool _scroll => _horizontalScroll == true || _verticallScroll == true;

    private void Awake()
    {
        _image = GetComponent<RawImage>();
    }

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

    private void OnGameEnded()
    {
        _verticallScroll = false;
        _horizontalScroll = false;
    }
}
