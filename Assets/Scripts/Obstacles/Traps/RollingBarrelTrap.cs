using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class RollingBarrelTrap : MovableObstacle
{
    private Animator _animator;

    private new void Awake()
    {
        _animator = GetComponent<Animator>();

        base.Awake();
    }

    protected override void ActivateTrap()
    {
        _animator.SetTrigger(ChooseAnimationState());
        IsActivated = true;
        Coroutine = ChangePosition(TargetPosition);
        StartCoroutine(Coroutine);
    }

    private string ChooseAnimationState()
    {
        return transform.localPosition == StartPosition ? AnimatorTrapController.States.SpinForward : AnimatorTrapController.States.SpinBackwards;
    }

    private IEnumerator ChangePosition(Vector3 targetPosition)
    {
        CoroutineIsActive = true;

        while (transform.localPosition != targetPosition)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPosition, Speed * Time.deltaTime);
            yield return null;
        }

        SetObstacleParametres();
        _animator.SetTrigger(AnimatorTrapController.States.StopSpin);
        CoroutineIsActive = false;
    }
}
