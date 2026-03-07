using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemyPatrolState : EnemyBaseState
{
    private Vector3 _patrolPosition;

    public EnemyPatrolState(EnemyBase enemy, EnemyHealthController healthController) : base(enemy, healthController) { }
    public override void EnterState()
    {
        base.EnterState();

        _patrolPosition = _enemy.GetPatrolPosition();
        _enemy.SetMovementSpeed(_enemy.Data.MovementSpeed);
        _enemy.AnimationController.PlayAnimation(GameConstant.EnemyAnimationData.MOVE_HASH, GameConstant.AnimationSettings.QUICK_TRANSITION);
    }
    public override void ExitState()
    {
        base.ExitState();
    }
    public override void Tick()
    {
        base.Tick();

        var distanceToTarget = Vector3.Distance(_enemy.transform.position, _patrolPosition);
        if (distanceToTarget <= 0.1f)
            _stateMachine.SwitchState<EnemyWaitState>();

        _enemy.MoveTo(_patrolPosition);
        _enemy.HandleRotation(_patrolPosition);
    }
}
