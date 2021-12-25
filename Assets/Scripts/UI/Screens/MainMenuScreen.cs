using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using SimpleInputNamespace;

public class MainMenuScreen : Screen
{
    [SerializeField] private Joystick _joystick;

    private bool _gameStarted = false;

    public event UnityAction PlayButtonClick;
    public event UnityAction ScreenTouched;

    private void OnEnable()
    {
        _joystick.ActivateJoystick += OnActivateJoystick;
    }

    private void OnDisable()
    {
        _joystick.ActivateJoystick -= OnActivateJoystick;
    }

    private void OnActivateJoystick()
    {
        if (_gameStarted == false)
        {
            _gameStarted = true;
            ScreenTouched?.Invoke();
        }
    }

    public override void Close()
    {
        CanvasGroup.alpha = 0;
        CanvasGroup.interactable = false;
        CanvasGroup.blocksRaycasts = false;
        SwipePanel.raycastTarget = true;
    }

    public override void Open()
    {
        _gameStarted = false;
        CanvasGroup.alpha = 1;
        CanvasGroup.interactable = true;
        CanvasGroup.blocksRaycasts = true;
        SwipePanel.raycastTarget = false;
    }
}
