using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerCollision))]
public class Player : MonoBehaviour
{
    [SerializeField] private BodyPart[] _bodyParts;
    [SerializeField] private States _state = States.Assembled;

    private PlayerCollision _playerCollision;
    private int _brokenPartCount = 0;
    private int _repairePartCount = 0;

    public event UnityAction LostLeftLeg;
    public event UnityAction LostRightLeg;
    public event UnityAction LostLegs;
    public event UnityAction RepairedLeftLeg;
    public event UnityAction RepairedRightLeg;
    public event UnityAction RepairedBody;
    public event UnityAction Died;

    private void Awake()
    {
        _playerCollision = GetComponent<PlayerCollision>();
    }

    private void OnEnable()
    {
        foreach (var bodyPart in _bodyParts)
        {
            bodyPart.Brokened += OnBrokened;
            bodyPart.Repaired += OnRepaired;
        }

        _playerCollision.RepairePartPicked += OnRepairePartPicked;
    }

    private void OnDisable()
    {
        foreach (var bodyPart in _bodyParts)
        {
            bodyPart.Brokened -= OnBrokened;
            bodyPart.Repaired -= OnRepaired;
        }

        _playerCollision.RepairePartPicked -= OnRepairePartPicked;
    }

    private void OnBrokened(BodyPartName bodyPartName)
    {
        _brokenPartCount++;
        ChooseCurrentState(States.Assembled, States.WithoutLeftLeg, States.WithoutRightLeg, States.WithoutLegs, LostLeftLeg, LostRightLeg, LostLegs, bodyPartName);

        if (_brokenPartCount == _bodyParts.Length)
            Died?.Invoke();
    }

    private void OnRepaired(BodyPartName bodyPartName)
    {
        ChooseCurrentState(States.WithoutLegs, States.WithoutRightLeg, States.WithoutLeftLeg, States.Assembled, RepairedLeftLeg, RepairedRightLeg, RepairedBody, bodyPartName);
    }

    private void ChooseCurrentState(States firstState, States secondState, States thirdState, States fourthtate, UnityAction firstAction, UnityAction secondAction, UnityAction thirdAction, BodyPartName bodyPartName)
    {
        if (_state == firstState)
        {
            if (bodyPartName == BodyPartName.LowerLeftLegPart)
                SetState(secondState, firstAction);
            else if (bodyPartName == BodyPartName.LowerRightLegPart)
                SetState(thirdState, secondAction);
        }
        else if (_state == secondState || _state == thirdState)
        {
            if (bodyPartName == BodyPartName.LowerRightLegPart || bodyPartName == BodyPartName.LowerLeftLegPart)
                SetState(fourthtate, thirdAction);
        }
    }

    private void SetState(States state, UnityAction action)
    {
        _state = state;
        action?.Invoke();
    }

    private void OnRepairePartPicked(Color color)
    {
        _repairePartCount++;

        RepaireBrokenParts(color);
    }

    private void RepaireBrokenParts(Color color)
    {
        foreach (var bodyPart in _bodyParts)
        {
            if (bodyPart.HasBroken == true && _repairePartCount > 0)
            {
                bodyPart.RepairePiece(color);
                _repairePartCount--;
                _brokenPartCount--;
            }
        }
    }
}

public enum States
{
    Assembled,
    WithoutLegs,
    WithoutLeftLeg,
    WithoutRightLeg
}
