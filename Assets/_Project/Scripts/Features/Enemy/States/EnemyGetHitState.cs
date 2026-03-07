using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemyGetHitState : EnemyBaseState
{
    public EnemyGetHitState(EnemyBase enemy, EnemyHealthController healthController) : base(enemy, healthController) { }

    public override void EnterState()
    {
        _enemy.AnimationController.PlayAnimation(GameConstant.EnemyAnimationData.GET_HIT_HASH, GameConstant.AnimationSettings.QUICK_TRANSITION);
    }

    public override void ExitState()
    {

    }

    public override void Tick()
    {
        if (_enemy.AnimationController.IsAnimationFinished())
            _stateMachine.SwitchState<EnemyChaseState>();
    }
}
