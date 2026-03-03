using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolState : IState
{
    private EnemyBase _enemy;
    private BaseStateMachine _stateMachine;

    private Vector3 _patrolPosition;

    public EnemyPatrolState(EnemyBase enemy) => _enemy = enemy;
    public void SetStateMachine(BaseStateMachine stateMachine) => _stateMachine = stateMachine;
    public void EnterState()
    {
        _patrolPosition = _enemy.GetPatrolPosition();
        _enemy.SetMovementSpeed(_enemy.Data.MovementSpeed);
    }
    public void ExitState()
    {

    }
    public void Tick()
    {
        var distanceToTarget = Vector3.Distance(_enemy.transform.position, _patrolPosition);
        if (distanceToTarget <= 0.1f)
        {
            Debug.Log("Enemy is changing State");
        }

        _enemy.MoveTo(_patrolPosition);
    }
}
