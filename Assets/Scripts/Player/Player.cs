using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private BodyPart[] _bodyParts;
    [SerializeField] private States _state = States.Assembled;

    public event UnityAction Assembled;
    public event UnityAction LostLeftLeg;
    public event UnityAction LostRightLeg;
    public event UnityAction LostLegs;

    /*public void RepairBody()
    {
        foreach (var item in _bodyParts)
        {
            if (item.isActiveAndEnabled == false)
                item.gameObject.SetActive(true);
        }
    }*/

    private void OnEnable()
    {
        foreach (var bodyPart in _bodyParts)
        {
            bodyPart.Broken += OnBroken;
        }
    }

    private void OnDisable()
    {
        foreach (var bodyPart in _bodyParts)
        {
            bodyPart.Broken -= OnBroken;
        }
    }

    private void OnBroken(BodyPartName bodyPartName)
    {
        if(_state == States.Assembled)
        {
            if(bodyPartName == BodyPartName.LowerLeftLegPart)
            {
                _state = States.WithoutLeftLeg;
                LostLeftLeg?.Invoke();
            }
            else if(bodyPartName == BodyPartName.LowerRightLegPart)
            {
                _state = States.WithoutRightLeg;
                LostRightLeg?.Invoke();
            }
        }
        else if(_state == States.WithoutLeftLeg || _state == States.WithoutRightLeg)
        {
            if (bodyPartName == BodyPartName.LowerRightLegPart || bodyPartName == BodyPartName.LowerLeftLegPart)
            {
                _state = States.WithoutLegs;
                LostLegs?.Invoke();
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
