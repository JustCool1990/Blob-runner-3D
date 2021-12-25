using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacuumCleaner : Obstacle
{
    [SerializeField, Range(-4, 2)] private float _verticalDistance;

    private void Awake()
    {
        SetObstacleParametres();
    }

    protected override void SetObstacleParametres(float waitingTime = 0)
    {
        transform.localPosition = new Vector3(transform.localPosition.x, _verticalDistance, transform.localPosition.z);
    }
}
