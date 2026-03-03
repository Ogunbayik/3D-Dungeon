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
        private const string ATTACK = "Player_Attack";

        public static readonly int IDLE_HASH = Animator.StringToHash(IDLE);
        public static readonly int MOVE_HASH = Animator.StringToHash(MOVE);
        public static readonly int JUMP_HASH = Animator.StringToHash(JUMP);
        public static readonly int ATTACK_HASH = Animator.StringToHash(ATTACK);
    }
    public class EnemyAnimationData
    {
        private const string WAIT = "Enemy_Wait";
        private const string MOVE = "Enemy_Move";
        private const string CHASE = "Enemy_Chase";
        private const string ATTACK = "Enemy_Attack";

        public static readonly int WAIT_HASH = Animator.StringToHash(WAIT);
        public static readonly int MOVE_HASH = Animator.StringToHash(MOVE);
        public static readonly int CHASE_HASH = Animator.StringToHash(CHASE);
        public static readonly int ATTACK_HASH = Animator.StringToHash(ATTACK);
    }
    public class GameSettings
    {
        public const float JumpGravityCoefficient = -2f;
    }
}
