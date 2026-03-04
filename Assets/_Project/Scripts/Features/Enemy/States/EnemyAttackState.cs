using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
    public EnemyAttackState(EnemyBase enemy) : base(enemy) { }

    public override void EnterState()
    {
        Debug.Log("Start Attacking");
        _enemy.AnimationController.PlayAnimation(GameConstant.EnemyAnimationData.ATTACK_HASH, GameConstant.AnimationSettings.QUICK_TRANSITION);
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
