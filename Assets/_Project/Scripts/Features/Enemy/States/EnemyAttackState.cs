using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
    public EnemyAttackState(EnemyBase enemy, EnemyHealthController healthController) : base(enemy, healthController) { }

    public override void EnterState()
    {
        base.EnterState();

        _enemy.AnimationController.PlayAnimation(GameConstant.EnemyAnimationData.ATTACK_HASH, GameConstant.AnimationSettings.QUICK_TRANSITION);
    }

    public override void ExitState()
    {
        base.ExitState();
    }
    public override void Tick()
    {
        if (_enemy.AnimationController.IsAnimationFinished())
            _stateMachine.SwitchState<EnemyChaseState>();
    }

}
