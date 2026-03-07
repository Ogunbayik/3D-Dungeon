using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemyWaitState : EnemyBaseState
{
    private float _waitTimer;

    public EnemyWaitState(EnemyBase enemy, EnemyHealthController healthController) : base(enemy, healthController) { }
    public override void EnterState()
    {
        base.EnterState();
        _waitTimer = _enemy.GetWaitTime();
        _enemy.AnimationController.PlayAnimation(GameConstant.EnemyAnimationData.WAIT_HASH, GameConstant.AnimationSettings.SMOOTH_TRANSITION);
    }
    public override void ExitState()
    {
        base.ExitState();
    }
    public override void Tick()
    {
        base.Tick();

        _waitTimer -= Time.deltaTime;

        if(_waitTimer <= 0)
        {
            _waitTimer = 0;
            _stateMachine.SwitchState<EnemyPatrolState>();
        }
    }
}
