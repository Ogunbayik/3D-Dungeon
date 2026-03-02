using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerGroundedState
{
    private float _transitionTime = 0.01f;
    public PlayerAttackState(PlayerController player) : base(player) { }

    public override void EnterState()
    {
        _player.AnimationControler.PlayAnimation(GameConstant.PlayerAnimationData.ATTACK_HASH, _transitionTime);
    }

    public override void ExitState()
    {

    }
    public override void Tick()
    {
        if (_player.AnimationControler.IsAnimationFinished())
            _stateMachine.SwitchState<PlayerIdleState>();
    }

}
