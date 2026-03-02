using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirborneState : IState
{
    private float _transitionTime = 0.05f;

    private StateMachine _stateMachine;
    private PlayerController _player;

    public PlayerAirborneState(PlayerController player)
    {
        _player = player;
    }
    public void SetStateMachine(StateMachine stateMachine) => _stateMachine = stateMachine;
    public void EnterState()
    {
        _player.HandleJump();
        _player.AnimationControler.PlayAnimation(GameConstant.PlayerAnimationData.JUMP_HASH, _transitionTime);
    }
    public void ExitState()
    {

    }
    public void Tick()
    {
        var direction = _player.GetInputDirection();

        _player.ApplyGravity();

        _player.Move(direction);

        if (_player.IsGrounded() && _player.VelocityY < 0)
            _stateMachine.SwitchState<PlayerIdleState>();
    }
}
