using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StepHandler: MonoBehaviour
{
    private Color _leftLegColor;
    private Color _RightLegColor;
    private Color _BellyColor;

    public event UnityAction<Color> LeftLegStepped;
    public event UnityAction<Color> RightLegStepped;
    public event UnityAction<Color> JumpedOnLeftLeg;
    public event UnityAction<Color> JumpedOnRightLeg;

    public void LeftLegStep()
    {
        LeftLegStepped?.Invoke(_leftLegColor);
    }

    public void RightLegStep()
    {
        RightLegStepped?.Invoke(_RightLegColor);
    }

    public void JumpOnLeftLeg()
    {
        JumpedOnLeftLeg?.Invoke(_leftLegColor);
    }

    public void JumpOnRightLeg()
    {
        JumpedOnRightLeg?.Invoke(_RightLegColor);
    }
}
