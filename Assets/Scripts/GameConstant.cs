using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameConstant
{
    public class PlayerInput
    {
        public const string HORIZONTAL_INPUT = "Horizontal";
        public const string VERTICAL_INPUT = "Vertical";
    }
    public class PlayerAnimationData
    {
        private const string SpeedParameter = "MovementSpeed";
        private const string BlendXParameter = "MoveX";
        private const string BlendZParameter = "MoveZ";
        private const string JumpParameter = "IsJump";

        public static readonly int SPEED_HASH = Animator.StringToHash(SpeedParameter);
        public static readonly int BLENDX_HASH = Animator.StringToHash(BlendXParameter);
        public static readonly int BLENDZ_HASH = Animator.StringToHash(BlendZParameter);
        public static readonly int JUMP_HASH = Animator.StringToHash(JumpParameter);
    }
    public class GameSettings
    {
        public const float JumpGravityCoefficient = -2f;
    }
}
