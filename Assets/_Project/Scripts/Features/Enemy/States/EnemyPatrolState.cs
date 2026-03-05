using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolState : EnemyBaseState
{
    private Vector3 _patrolPosition;

    public EnemyPatrolState(EnemyBase enemy) : base(enemy) { }
    public override void EnterState()
    {
        _patrolPosition = _enemy.GetPatrolPosition();
        _enemy.SetMovementSpeed(_enemy.Data.MovementSpeed);
        _enemy.AnimationController.PlayAnimation(GameConstant.EnemyAnimationData.MOVE_HASH, GameConstant.AnimationSettings.QUICK_TRANSITION);
    }
    public override void ExitState()
    {

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
