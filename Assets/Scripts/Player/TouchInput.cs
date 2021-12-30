using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TouchInput : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool _gameBegin = false;
    private bool _controlCharacter = false;
    private bool _canMove => _gameBegin == true && _controlCharacter == true;

    public event UnityAction<float> Touched;
    public event UnityAction Untouched;
    public event UnityAction ActivateMovement;

    private void Update()
    {
        if (_canMove == true)
            Touched?.Invoke(Input.GetAxis("Mouse X"));
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (_gameBegin == false)
        {
            ActivateMovement?.Invoke();
            _gameBegin = true;
        }
        
        _controlCharacter = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _controlCharacter = false;
        Untouched?.Invoke();
    }
}
