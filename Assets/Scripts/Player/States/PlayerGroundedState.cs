using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerGroundedState : IState
{
    protected StateMachine _stateMachine;
    protected PlayerController _player;
    
    public PlayerGroundedState(PlayerController player)
    {
        _player = player;
    }
    public void SetStateMachine(StateMachine stateMachine) => _stateMachine = stateMachine;
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
