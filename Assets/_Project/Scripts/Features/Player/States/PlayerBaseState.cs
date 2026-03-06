using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGame.Core.Enums;
using Zenject;

public abstract class PlayerBaseState : IState
{
    private SignalBus _signalBus;

    protected PlayerBase _player;
    protected BaseStateMachine _stateMachine;
    public PlayerBaseState(PlayerBase player, SignalBus signalBus)
    {
        _player = player;
        _signalBus = signalBus;
    }
    public void SetStateMachine(BaseStateMachine stateMachine) => _stateMachine = stateMachine;
    public virtual void EnterState()
    {
        _signalBus.Subscribe<GameSignal.OnPlayerModeChangedSignal>(OnPlayerDeath);
    }
    public virtual void ExitState()
    {
        _signalBus.Unsubscribe<GameSignal.OnPlayerModeChangedSignal>(OnPlayerDeath);
    }
    public void OnPlayerDeath(GameSignal.OnPlayerModeChangedSignal signal)
    {
        if (signal.NewMode != PlayerMode.Death)
            return;

        _stateMachine.SwitchState<PlayerDeathState>();
    }
    private void HealthController_OnDeath() => _stateMachine.SwitchState<PlayerDeathState>();
    public abstract void Tick();

    
}
