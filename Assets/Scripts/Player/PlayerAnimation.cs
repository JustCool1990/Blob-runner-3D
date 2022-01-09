using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private GameModeSwitcher _gameModeSwitcher;
    [SerializeField] private float _delay;

    private float _lastDelay;
    private Player _player;
    private Animator _animator;
    private IEnumerator _coroutine;
    private bool _coroutineIsActive = false;

    private void Awake()
    {
        _lastDelay = _delay;
        _player = GetComponentInParent<Player>();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _gameModeSwitcher.GameStarted += OnGameStarted;
        _player.LostLeftLeg += OnLostLeftLeg;
        _player.LostRightLeg += OnLostRightLeg;
        _player.LostLegs += OnLostLegs;
        _player.RepairedLeftLeg += OnRepairedLeftLeg;
        _player.RepairedRightLeg += OnRepairedRightLeg;
        _player.RepairedBody += OnRepairedBody;
    }

    private void OnDisable()
    {
        _gameModeSwitcher.GameStarted -= OnGameStarted;
        _player.LostLeftLeg -= OnLostLeftLeg;
        _player.LostRightLeg -= OnLostRightLeg;
        _player.LostLegs -= OnLostLegs;
        _player.RepairedLeftLeg -= OnRepairedLeftLeg;
        _player.RepairedRightLeg -= OnRepairedRightLeg;
        _player.RepairedBody -= OnRepairedBody;
    }

    private void OnGameStarted()
    {
        /*DisableAnimations();
        _animator.SetBool(AnimatorPlayerController.States.Run, true);*/

        DeactivateCoroutine();
        ActivateCoroutine(AnimatorPlayerController.States.Run);
    }

    private void OnLostLeftLeg()
    {
        DeactivateCoroutine();
        ActivateCoroutine(AnimatorPlayerController.States.JumpRightLeg);
    }
    
    private void OnLostRightLeg()
    {
        DeactivateCoroutine();
        ActivateCoroutine(AnimatorPlayerController.States.JumpLeftLeg);
    }
    
    private void OnLostLegs()
    {
        DeactivateCoroutine();
        ActivateCoroutine(AnimatorPlayerController.States.Crawl);
    }

    private void OnRepairedLeftLeg()
    {
        DeactivateCoroutine();
        ActivateCoroutine(AnimatorPlayerController.States.JumpLeftLeg, true);
    }

    private void OnRepairedRightLeg()
    {
        DeactivateCoroutine();
        ActivateCoroutine(AnimatorPlayerController.States.JumpRightLeg, true);
    }

    private void OnRepairedBody()
    {
        DeactivateCoroutine();
        ActivateCoroutine(AnimatorPlayerController.States.Run, true);
    }

    private void DisableAnimations()
    {
        _animator.SetBool(AnimatorPlayerController.States.Run, false);
        _animator.SetBool(AnimatorPlayerController.States.JumpRightLeg, false);
        _animator.SetBool(AnimatorPlayerController.States.JumpLeftLeg, false);
        _animator.SetBool(AnimatorPlayerController.States.Crawl, false);
    }

    private IEnumerator AnimationChangeDelay(string animationState, bool standUP = false)
    {
        _coroutineIsActive = true;
        DisableAnimations();

        while (_lastDelay > 0)
        {
            _lastDelay -= Time.deltaTime;
            yield return null;
        }

        _animator.SetBool(animationState, true);

        if(standUP == true)
            _animator.SetTrigger(AnimatorPlayerController.States.StandUP);

        _lastDelay = _delay;
        _coroutineIsActive = false;
    }

    private void ActivateCoroutine(string animationState, bool standUP = false)
    {
        _coroutine = AnimationChangeDelay(animationState, standUP);
        StartCoroutine(_coroutine);
    }

    private void DeactivateCoroutine()
    {
        if (_coroutineIsActive == true)
        {
            StopCoroutine(_coroutine);
            _coroutineIsActive = false;
        }
    }
}
