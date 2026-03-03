using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaitState : IState
{
    private EnemyBase _enemy;
    private BaseStateMachine _stateMachine;

    private float _waitTimer;

    public EnemyWaitState(EnemyBase enemy) => _enemy = enemy;
    public void SetStateMachine(BaseStateMachine stateMachine) => _stateMachine = stateMachine;
    public void EnterState()
    {
        Debug.Log("Enemy is looking around");
        _waitTimer = _enemy.GetWaitTime();
    }
    public void ExitState()
    {

    }
    public void Tick()
    {
        _waitTimer -= Time.deltaTime;

        if(_waitTimer <= 0)
        {
            _waitTimer = 0;
            _stateMachine.SwitchState<EnemyPatrolState>();
        }
    }
}
