using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirborneState : PlayerBaseState
{
    public PlayerAirborneState(PlayerBase player, PlayerHealthController healthController) : base(player, healthController) { }
    public override void EnterState()
    {
        base.EnterState();

        _player.HandleJump();
        _player.AnimationControler.PlayAnimation(GameConstant.PlayerAnimationData.JUMP_HASH, GameConstant.AnimationSettings.QUICK_TRANSITION);
    }
    public override void ExitState() => base.ExitState();
    public override void Tick()
    {
        var direction = _player.GetInputDirection();

        _player.ApplyGravity();

        _player.Move(direction);

        if (_player.IsGrounded() && _player.VelocityY < 0)
            _stateMachine.SwitchState<PlayerIdleState>();
    }
}
