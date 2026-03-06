using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGame.Core.Enums;

public abstract class PlayerBaseState : IState
{
    protected PlayerBase _player;
    protected BaseStateMachine _stateMachine;
    protected PlayerHealthController _healthController;
    public PlayerBaseState(PlayerBase player, PlayerHealthController healthController)
    {
        _player = player;
        _healthController = healthController;
    }
    public void SetStateMachine(BaseStateMachine stateMachine) => _stateMachine = stateMachine;
    public virtual void EnterState()
    {
        _healthController.OnDeath += HealthController_OnDeath;
    }
    public virtual void ExitState()
    {
        _healthController.OnDeath -= HealthController_OnDeath;
    }
    private void HealthController_OnDeath() => _stateMachine.SwitchState<PlayerDeathState>();
    public abstract void Tick();

    
}
