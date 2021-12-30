using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using SimpleInputNamespace;

public class MainMenuScreen : Screen
{
    [SerializeField] private TouchInput _touchInput;

    private bool _gameStarted = false;

    public event UnityAction ScreenTouched;

    private void OnEnable()
    {
        _touchInput.ActivateMovement += OnActivateMovement;
    }

    private void OnDisable()
    {
        _touchInput.ActivateMovement -= OnActivateMovement;
    }

    private void OnActivateMovement()
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
        TouchPanel.raycastTarget = true;
    }

    public override void Open()
    {
        _gameStarted = false;
        CanvasGroup.alpha = 1;
        CanvasGroup.interactable = true;
        CanvasGroup.blocksRaycasts = true;
        TouchPanel.raycastTarget = true;
    }
}
