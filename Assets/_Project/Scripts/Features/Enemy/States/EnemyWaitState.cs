using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaitState : EnemyBaseState
{
    private float _waitTimer;

    public EnemyWaitState(EnemyBase enemy) : base(enemy) { }
    public override void EnterState()
    {
        Debug.Log("Enemy is looking around");
        _waitTimer = _enemy.GetWaitTime();
        _enemy.AnimationController.PlayAnimation(GameConstant.EnemyAnimationData.WAIT_HASH, GameConstant.AnimationSettings.SMOOTH_TRANSITION);
    }
    public override void ExitState()
    {

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
