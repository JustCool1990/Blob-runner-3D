using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StepHandler))]
public class StepEffectRenderer : MonoBehaviour
{
    [SerializeField] private ParticleSystem _leftStepBlobEffect;
    [SerializeField] private ParticleSystem _rightStepBlobEffect;
    [SerializeField] private ParticleSystem _leftJumpBlobEffect;
    [SerializeField] private ParticleSystem _rightJumpBlobEffect;

    private StepHandler _stepHandler;

    private void Awake()
    {
        _stepHandler = GetComponent<StepHandler>();
    }

    private void OnEnable()
    {
        _stepHandler.LeftLegStepped += OnLeftLegStepped;
        _stepHandler.RightLegStepped += OnRightLegStepped;
        _stepHandler.JumpedOnLeftLeg += OnJumpedOnLeftLeg;
        _stepHandler.JumpedOnRightLeg += OnJumpedOnRightLeg;
    }

    private void OnDisable()
    {
        _stepHandler.LeftLegStepped -= OnLeftLegStepped;
        _stepHandler.RightLegStepped -= OnRightLegStepped;
        _stepHandler.JumpedOnLeftLeg -= OnJumpedOnLeftLeg;
        _stepHandler.JumpedOnRightLeg -= OnJumpedOnRightLeg;
    }

    private void OnLeftLegStepped(Color color)
    {
        _leftStepBlobEffect.Play();
    }
    
    private void OnRightLegStepped(Color color)
    {

    }
    
    private void OnJumpedOnLeftLeg(Color color)
    {

    }
    
    private void OnJumpedOnRightLeg(Color color)
    {

    }
}
