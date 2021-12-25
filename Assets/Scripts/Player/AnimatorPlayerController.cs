using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AnimatorPlayerController
{
    public static class States
    {
        public const string Idle = nameof(Idle);
        public const string Run = nameof(Run);
        public const string JumpLeftLeg = nameof(JumpLeftLeg);
        public const string JumpRightLeg = nameof(JumpRightLeg);
        public const string Crawl = nameof(Crawl);
        public const string StandUP = nameof(StandUP);
    }
}
