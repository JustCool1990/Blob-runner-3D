using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgressBar : MonoBehaviour
{
    [SerializeField] private Transform _lastChunk;
    [SerializeField] private Slider _progressBar;

    private float _endValue;
    private float _currentValue;

    private void Start()
    {
        _endValue = _lastChunk.position.x;
    }

    private void FixedUpdate()
    {
        if(_progressBar.value < _progressBar.maxValue)
        {
            _currentValue = _progressBar.maxValue - (_lastChunk.position.x / _endValue);
            _progressBar.value = _currentValue;
        }
    }
}
