using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerGroundedState : IState
{
    protected BaseStateMachine _stateMachine;
    protected PlayerBase _player;
    
    public PlayerGroundedState(PlayerBase player)
    {
        _player = player;
    }
    public void SetStateMachine(BaseStateMachine stateMachine) => _stateMachine = stateMachine;
    public abstract void EnterState();
    public abstract void ExitState();
    public virtual void Tick()
    {
        if (_player.PressedAttack())
            _stateMachine.SwitchState<PlayerAttackState>();

        if (_player.PressedJump())
            _stateMachine.SwitchState<PlayerAirborneState>();
    }
}
