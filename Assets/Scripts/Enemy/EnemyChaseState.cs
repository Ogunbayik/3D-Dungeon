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
        _enemy.AnimationController.PlayAnimation(GameConstant.EnemyAnimationData.CHASE_HASH, 0.05f);
    }
    public override void ExitState()
    {

    }
    public override void Tick()
    {
        _enemy.MoveTo(_player.transform.position);

        if (_enemy.CheckPlayerInArea() == null)
            _stateMachine.SwitchState<EnemyPatrolState>();
    }
}
