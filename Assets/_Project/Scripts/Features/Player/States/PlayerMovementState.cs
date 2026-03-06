using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerMovementState : PlayerGroundedState
{
    public PlayerMovementState(PlayerBase player, SignalBus signalBus) : base(player, signalBus) { }

    public override void EnterState()
    {
        base.EnterState();
        _player.AnimationControler.PlayAnimation(GameConstant.PlayerAnimationData.MOVE_HASH, GameConstant.AnimationSettings.QUICK_TRANSITION);
    }
    public override void ExitState()
    {
        base.ExitState();
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
