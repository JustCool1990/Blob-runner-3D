using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private GameModeSwitcher _gameModeSwitcher;

    private Player _player;
    private Animator _animator;

    private void Awake()
    {
        _player = GetComponentInParent<Player>();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _gameModeSwitcher.GameStarted += OnGameStarted;
        _player.LostLeftLeg += OnLostLeftLeg;
        _player.LostRightLeg += OnLostRightLeg;
        _player.LostLegs += OnLostLegs;
    }

    private void OnDisable()
    {
        _gameModeSwitcher.GameStarted -= OnGameStarted;
        _player.LostLeftLeg -= OnLostLeftLeg;
        _player.LostRightLeg -= OnLostRightLeg;
        _player.LostLegs -= OnLostLegs;
    }

    private void OnGameStarted()
    {
        DisableAnimations();
        _animator.SetBool(AnimatorPlayerController.States.Run, true);
    }

    private void OnLostLeftLeg()
    {
        DisableAnimations();
        _animator.SetBool(AnimatorPlayerController.States.JumpRightLeg, true);
    }
    
    private void OnLostRightLeg()
    {
        DisableAnimations();
        _animator.SetBool(AnimatorPlayerController.States.JumpLeftLeg, true);
    }
    
    private void OnLostLegs()
    {
        DisableAnimations();
        _animator.SetBool(AnimatorPlayerController.States.Crawl, true);
    }

    private void RepairBody()
    {
        DisableAnimations();
        _animator.SetBool(AnimatorPlayerController.States.Run, true);
        _animator.SetTrigger(AnimatorPlayerController.States.StandUP);
    }

    private void DisableAnimations()
    {
        _animator.SetBool(AnimatorPlayerController.States.Run, false);
        _animator.SetBool(AnimatorPlayerController.States.JumpRightLeg, false);
        _animator.SetBool(AnimatorPlayerController.States.JumpLeftLeg, false);
        _animator.SetBool(AnimatorPlayerController.States.Crawl, false);
    }
}
