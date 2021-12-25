using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using SimpleInputNamespace;

public class TouchInput : MonoBehaviour
{
    //private float _horizontalMove;
    [SerializeField] private GameModeSwitcher _gameModeSwitcher;
    [SerializeField] private Joystick _joystick;

    private bool _gameBegin = false;

    public event UnityAction<float> Touched;
    public event UnityAction Untouched;
    private void OnEnable()
    {
        _gameModeSwitcher.GameStarted += OnGameStarted;
        _joystick.DeactivateJoystick += OnDeactivateJoystick;
    }

    private void OnDisable()
    {
        _gameModeSwitcher.GameStarted -= OnGameStarted;
        _joystick.DeactivateJoystick -= OnDeactivateJoystick;
    }

    private void Update()
    {
        /*if (SimpleInput.GetAxisRaw("Horizontal") >= 0.01f || SimpleInput.GetAxisRaw("Horizontal") <= -0.01f)
            Touched?.Invoke(SimpleInput.GetAxisRaw("Horizontal"));*/

        if(_gameBegin == true)
            Touched?.Invoke(Input.GetAxis("Mouse X"));
        //Debug.Log(Input.GetAxis("Mouse X"));
            
    }

    private void OnGameStarted()
    {
        _gameBegin = true;
    }

    private void OnDeactivateJoystick()
    {
        Untouched?.Invoke();
    }
}
