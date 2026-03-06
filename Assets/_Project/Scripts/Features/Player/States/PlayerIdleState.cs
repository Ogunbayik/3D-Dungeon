using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(PlayerBase player, SignalBus signalBus) : base(player, signalBus) { }
    public override void EnterState()
    {
        base.EnterState();
        _player.AnimationControler.PlayAnimation(GameConstant.PlayerAnimationData.IDLE_HASH, GameConstant.AnimationSettings.QUICK_TRANSITION);
    }

    public override void ExitState()
    {
        base.ExitState();
    }
    public override void Tick()
    {
        base.Tick();

        if (_player.IsMoving())
            _stateMachine.SwitchState<PlayerMovementState>();
    }

}
