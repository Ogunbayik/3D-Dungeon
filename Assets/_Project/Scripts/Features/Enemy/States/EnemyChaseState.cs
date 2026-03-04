using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : EnemyBaseState
{
    private PlayerBase _player;
    public EnemyChaseState(EnemyBase enemy) : base(enemy) { }
    public override void EnterState()
    {
        Debug.Log("Chasing!");
        _player = _enemy.CheckPlayerInArea();
        _enemy.SetMovementSpeed(_enemy.Data.ChaseSpeed);
        _enemy.AnimationController.PlayAnimation(GameConstant.EnemyAnimationData.CHASE_HASH, GameConstant.AnimationSettings.QUICK_TRANSITION);
    }
    public override void ExitState()
    {

    }
    public override void Tick()
    {
        var distanceToPlayer = Vector3.Distance(_enemy.transform.position, _player.transform.position);
        if (distanceToPlayer <= _enemy.Data.AttackDistance)
            _stateMachine.SwitchState<EnemyAttackState>();

        _enemy.MoveTo(_player.transform.position);

        if (_enemy.CheckPlayerInArea() == null)
            _stateMachine.SwitchState<EnemyPatrolState>();
    }
}
