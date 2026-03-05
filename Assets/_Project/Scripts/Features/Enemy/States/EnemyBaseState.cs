using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBaseState : IState
{
    protected EnemyBase _enemy;
    protected EnemyHealthController _healthController;
    protected BaseStateMachine _stateMachine;

    public EnemyBaseState(EnemyBase enemy, EnemyHealthController healthController)
    {
        _enemy = enemy;
        _healthController = healthController;
    }
    public void SetStateMachine(BaseStateMachine stateMachine) => _stateMachine = stateMachine;
    public virtual void EnterState()
    {
        _healthController.OnHealthChanged += HealthController_OnHealthChanged;
        _healthController.OnDeath += HealthController_OnDeath;
    }
    public virtual void ExitState()
    {
        _healthController.OnHealthChanged -= HealthController_OnHealthChanged;
        _healthController.OnDeath -= HealthController_OnDeath;
    }
    private void HealthController_OnHealthChanged(int obj) => _stateMachine.SwitchState<EnemyGetHitState>();
    private void HealthController_OnDeath() => _stateMachine.SwitchState<EnemyDeathState>();
    public virtual void Tick()
    {
        if (_enemy.CheckPlayerInArea() != null)
            _stateMachine.SwitchState<EnemyChaseState>();
    }
}
