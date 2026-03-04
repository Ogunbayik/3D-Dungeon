using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(PlayerBase player) : base(player) { }

    public override void EnterState()
    {
        Debug.Log("Player is Idle!");
        _player.AnimationControler.PlayAnimation(GameConstant.PlayerAnimationData.IDLE_HASH, 0.1f);
    }

    public override void ExitState()
    {

    }
    public override void Tick()
    {
        base.Tick();

        if (_player.IsMoving())
            _stateMachine.SwitchState<PlayerMovementState>();
    }

}
