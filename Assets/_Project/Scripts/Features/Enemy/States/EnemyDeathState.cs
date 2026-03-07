using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemyDeathState : EnemyBaseState
{
    public EnemyDeathState(EnemyBase enemy, EnemyHealthController healthController) : base(enemy, healthController) { }
    public override void EnterState()
    {
        //TODO en son patlama efekti falan eklenebilir
        base.EnterState();
        _enemy.AnimationController.PlayAnimation(GameConstant.EnemyAnimationData.DEATH_HASH, GameConstant.AnimationSettings.QUICK_TRANSITION);
        _enemy.transform.GetComponent<BoxCollider>().enabled = false;
    }
    public override void ExitState()
    {
        base.ExitState();
    }
    public override void Tick()
    {

    }
}
