using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MotionHandler))]
public class StepEffectRenderer : MonoBehaviour
{
    [SerializeField] private GameModeSwitcher _gameModeSwitcher;
    [SerializeField] private ParticleSystem _legBlobEffect;
    [SerializeField] private ParticleSystem _bellyTrackEffect;

    private Player _player;
    private MotionHandler _motionHandler;
    private bool _showBellyTrace = false;
    private bool _canShowEffect = false;

    private void Awake()
    {
        _player = GetComponentInParent<Player>();
        _motionHandler = GetComponent<MotionHandler>();
    }

    private void OnEnable()
    {
        _gameModeSwitcher.GameStarted += OnGameStarted;
        _motionHandler.LeftLegStepped += OnLegTouchPlatform;
        _motionHandler.RightLegStepped += OnLegTouchPlatform;
        _motionHandler.JumpedOnLeftLeg += OnLegTouchPlatform;
        _motionHandler.JumpedOnRightLeg += OnLegTouchPlatform;
        _motionHandler.Falled += OnFalled;
        _motionHandler.Risen += OnRisen;
        _player.Died += OnDied;
    }

    private void OnDisable()
    {
        _gameModeSwitcher.GameStarted -= OnGameStarted;
        _motionHandler.LeftLegStepped -= OnLegTouchPlatform;
        _motionHandler.RightLegStepped -= OnLegTouchPlatform;
        _motionHandler.JumpedOnLeftLeg -= OnLegTouchPlatform;
        _motionHandler.JumpedOnRightLeg -= OnLegTouchPlatform;
        _motionHandler.Falled -= OnFalled;
        _motionHandler.Risen -= OnRisen;
        _player.Died -= OnDied;
    }

    private void OnGameStarted()
    {
        _canShowEffect = true;
    }

    private void OnLegTouchPlatform(Transform legTransform, Color color)
    {
        _legBlobEffect.transform.position = new Vector3(_legBlobEffect.transform.position.x, _legBlobEffect.transform.position.y, legTransform.position.z);
        _legBlobEffect.startColor = color;
        _legBlobEffect.Play();
    }

    private void OnFalled(BodyPart belly, Color color)
    {
        if(_canShowEffect == true)
            StartCoroutine(LeaveBellyTrace(belly, color));
    }

    private IEnumerator LeaveBellyTrace(BodyPart belly, Color color)
    {
        _showBellyTrace = true;
        _bellyTrackEffect.startColor = color;
        _bellyTrackEffect.Play();

        while (_showBellyTrace == true)
        {
            _bellyTrackEffect.transform.position = new Vector3(_bellyTrackEffect.transform.position.x, _bellyTrackEffect.transform.position.y, belly.transform.position.z);

            yield return null;
        }
    }

    private void OnRisen()
    {
        _showBellyTrace = false;
        _bellyTrackEffect.Stop();
    }

    private void OnDied()
    {
        _canShowEffect = false;
        _showBellyTrace = false;
        _bellyTrackEffect.Pause();
        _legBlobEffect.Pause();
    }
}
