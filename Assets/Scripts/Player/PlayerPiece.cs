using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPiece : MonoBehaviour
{
    private float _movingSpeed = 7;
    private Vector3 _moveDirection = new Vector3(0, 0, 1);
    private bool _mooving = false;

    private void FixedUpdate()
    {
        if(_mooving == true)
            transform.Translate(_moveDirection * _movingSpeed * Time.deltaTime);
    }

    public void SeparatePiece()
    {
        gameObject.SetActive(false);
    }
}
