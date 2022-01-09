using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MotionHandler: MonoBehaviour
{
    [SerializeField] private BodyPart _leftLeg;
    [SerializeField] private BodyPart _rightLeg;
    [SerializeField] private BodyPart _belly;

    public event UnityAction<Transform, Color> LeftLegStepped;
    public event UnityAction<Transform, Color> RightLegStepped;
    public event UnityAction<Transform, Color> JumpedOnLeftLeg;
    public event UnityAction<Transform, Color> JumpedOnRightLeg;
    public event UnityAction<BodyPart, Color> Falled;
    public event UnityAction Risen;

    public void LeftLegStep()
    {
        LeftLegStepped?.Invoke(_leftLeg.transform, _leftLeg.BodyPartColor);
    }

    public void RightLegStep()
    {
        RightLegStepped?.Invoke(_rightLeg.transform, _rightLeg.BodyPartColor);
    }

    public void JumpOnLeftLeg()
    {
        JumpedOnLeftLeg?.Invoke(_leftLeg.transform, _leftLeg.BodyPartColor);
    }

    public void JumpOnRightLeg()
    {
        JumpedOnRightLeg?.Invoke(_rightLeg.transform, _rightLeg.BodyPartColor);
    }

    public void FallDown()
    {
        Falled?.Invoke(_belly, _belly.BodyPartColor);
    }

    public void StandUP()
    {
        Risen?.Invoke();
    }
}
