using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorTrapController : MonoBehaviour
{
    public static class States
    {
        public const string Idle = nameof(Idle);
        public const string SpinForward = nameof(SpinForward);
        public const string SpinBackwards = nameof(SpinBackwards);
        public const string StopSpin = nameof(StopSpin);
    }
}
