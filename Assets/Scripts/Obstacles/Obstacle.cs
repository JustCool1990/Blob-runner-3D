using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
    protected abstract void SetObstacleParametres(float waitingTime = 0);
}
