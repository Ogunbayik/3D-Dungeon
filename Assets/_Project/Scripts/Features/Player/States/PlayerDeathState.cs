using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerDeathState : PlayerGroundedState
{
    public PlayerDeathState(PlayerBase player, SignalBus signalBus) : base(player, signalBus) { }
    public override void EnterState()
    {
        //TODO Ölüm Sequence kurulabilir. ölüm animasyonu - Kamera yakýnlaþmasý - Tekrar doðma UI panel
        base.EnterState();
        Debug.Log("Player is dead");
        _player.AnimationControler.PlayAnimation(GameConstant.PlayerAnimationData.DEATH_HASH, GameConstant.AnimationSettings.QUICK_TRANSITION);
    }

    public override void ExitState()
    {
        base.ExitState();
    }
    public override void Tick()
    {
        
    }
    
}
