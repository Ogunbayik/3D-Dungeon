using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementState : PlayerGroundedState
{
    public PlayerMovementState(PlayerController player) : base(player) { }

    public override void EnterState()
    {
        _player.AnimationControler.PlayAnimation(GameConstant.PlayerAnimationData.MOVE_HASH, 0.1f);
    }

    public override void ExitState()
    {

    }
    public override void Tick()
    {
        base.Tick();

        if (!_player.IsMoving())
            _stateMachine.SwitchState<PlayerIdleState>();

        var direction = _player.GetInputDirection();
        _player.Move(direction);

    }
}
