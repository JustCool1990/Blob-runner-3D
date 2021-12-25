using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObstacle : Obstacle
{
    [SerializeField] protected float RotatonSpeed;
    [SerializeField] protected bool RotateClockwise = false;

    private float _rotateY = 0;
    private bool _resetRotate => _rotateY > 360;

    private void FixedUpdate()
    {
        _rotateY += RotatonSpeed * Time.deltaTime * (RotateClockwise == true? 1 : -1);
        transform.rotation = Quaternion.Euler(0, _rotateY, 0);

        if (_resetRotate == true)
            SetObstacleParametres();
    }

    protected override void SetObstacleParametres(float waitingTime = 0)
    {
        _rotateY = 0;
    }
}
