using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovableObstacle : Obstacle
{
    [SerializeField] protected float Speed;
    [SerializeField] protected float MinIdleTime;
    [SerializeField] protected float MaxIdleTime;
    [SerializeField] protected Vector3 StartPosition;
    [SerializeField] protected Vector3 EndPosition;

    protected Vector3 TargetPosition;
    protected float IdleTime;
    protected bool IsActivated;
    protected IEnumerator Coroutine;
    protected bool CoroutineIsActive = false;

    protected void Awake()
    {
        SetObstacleParametres();
    }

    protected void OnDisable()
    {
        if (CoroutineIsActive == true)
        {
            StopCoroutine(Coroutine);
            CoroutineIsActive = false;
        }

        SetObstacleParametres();
    }

    private void FixedUpdate()
    {
        if (IsActivated == false)
            IdleTime -= Time.deltaTime;

        if (IdleTime <= 0 && IsActivated == false)
        {
            ActivateTrap();
        }
    }

    protected void SetObstacleParametres(float waitingTime = 0)
    {
        IdleTime = waitingTime > 0? waitingTime : Random.Range(MinIdleTime, MaxIdleTime);
        TargetPosition = transform.localPosition == StartPosition ? EndPosition : StartPosition;
        IsActivated = false;
    }

    protected abstract void ActivateTrap();
}
