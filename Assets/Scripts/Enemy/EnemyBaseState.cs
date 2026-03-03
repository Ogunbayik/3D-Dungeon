using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBaseState : IState
{
    protected EnemyBase _enemy;
    protected BaseStateMachine _stateMachine;

    public EnemyBaseState(EnemyBase enemy) => _enemy = enemy;
    public void SetStateMachine(BaseStateMachine stateMachine) => _stateMachine = stateMachine;

    public abstract void EnterState();
    public abstract void ExitState();
    public virtual void Tick()
    {
        if (_enemy.CheckPlayerInArea() != null)
            _stateMachine.SwitchState<EnemyChaseState>();
    }
}
