using MyGame.Core.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerGroundedState : PlayerBaseState
{
    protected PlayerGroundedState(PlayerBase player, PlayerHealthController healthController) : base(player, healthController) { }
    public override void EnterState() => base.EnterState();
    public override void ExitState() => base.ExitState();
    public override void Tick()
    {
        if (_player.PressedAttack() && _player.CurrentMode == PlayerMode.Combat)
            _stateMachine.SwitchState<PlayerAttackState>();

        if (_player.PressedJump())
            _stateMachine.SwitchState<PlayerAirborneState>();
    }
}
