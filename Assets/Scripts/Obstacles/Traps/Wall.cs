using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MovableObstacle
{
    [SerializeField] private float _fallingSpeed;
    [SerializeField] private float _stayDownTime;

    private bool _wallFalled => transform.localPosition == EndPosition;

    protected override void ActivateTrap()
    {
        IsActivated = true;
        Coroutine = ChangePosition(TargetPosition, _wallFalled);
        StartCoroutine(Coroutine);
    }

    private IEnumerator ChangePosition(Vector3 targetPosition, bool wallFalled)
    {
        CoroutineIsActive = true;

        while (transform.localPosition != targetPosition)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPosition, (wallFalled == true ? Speed : _fallingSpeed) * Time.deltaTime);
            yield return null;
        }

        SetObstacleParametres(wallFalled == true? 0 : _stayDownTime);
        CoroutineIsActive = false;
    }
}
