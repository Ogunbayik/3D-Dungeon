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
        private const string IDLE = "Player_Idle";
        private const string MOVE = "Player_Move";
        private const string JUMP = "Player_Jump";

        public static readonly int IDLE_HASH = Animator.StringToHash(IDLE);
        public static readonly int MOVE_HASH = Animator.StringToHash(MOVE);
        public static readonly int JUMP_HASH = Animator.StringToHash(JUMP);
    }
    public class GameSettings
    {
        public const float JumpGravityCoefficient = -2f;
    }
}
