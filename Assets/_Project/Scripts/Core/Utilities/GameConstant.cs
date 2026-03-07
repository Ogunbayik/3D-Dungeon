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
        private const string DEATH = "Player_Death";

        public static readonly int IDLE_HASH = Animator.StringToHash(IDLE);
        public static readonly int MOVE_HASH = Animator.StringToHash(MOVE);
        public static readonly int JUMP_HASH = Animator.StringToHash(JUMP);
        public static readonly int ATTACK_HASH = Animator.StringToHash(ATTACK);
        public static readonly int DEATH_HASH = Animator.StringToHash(DEATH);
    }
    public class EnemyAnimationData
    {
        private const string WAIT = "Enemy_Wait";
        private const string MOVE = "Enemy_Move";
        private const string CHASE = "Enemy_Chase";
        private const string ATTACK = "Enemy_Attack";
        private const string GET_HIT = "Enemy_GetHit";
        private const string DEATH = "Enemy_Death";

        public static readonly int WAIT_HASH = Animator.StringToHash(WAIT);
        public static readonly int MOVE_HASH = Animator.StringToHash(MOVE);
        public static readonly int CHASE_HASH = Animator.StringToHash(CHASE);
        public static readonly int ATTACK_HASH = Animator.StringToHash(ATTACK);
        public static readonly int GET_HIT_HASH = Animator.StringToHash(GET_HIT);
        public static readonly int DEATH_HASH = Animator.StringToHash(DEATH);
    }
    public class AnimationSettings
    {
        public const float QUICK_TRANSITION = 0.05f;
        public const float SMOOTH_TRANSITION = 0.2f;
    }
    public class GameSettings
    {
        public const float JUMPGRAVITYCOEFFICIENT = -2f;
    }
    public class CameraSettings
    {
        public const int ACTIVE_PRIORITY = 10;
        public const int DEACTIVE_PRIORITY = 1;
    }
    
    public class GameLayer
    {
        public const int PLAYER_LAYER = 7;
        public const int PLAYER_DEATH_LAYER = 8;
        public const int ENEMY_LAYER = 9;
    }
}
