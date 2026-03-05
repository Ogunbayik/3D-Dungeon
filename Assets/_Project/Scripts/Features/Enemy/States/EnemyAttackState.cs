using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading;
using System;

public class EnemyAttackState : EnemyBaseState
{
    private CancellationTokenSource _cts;

    public EnemyAttackState(EnemyBase enemy, EnemyHealthController healthController) : base(enemy, healthController) { }

    public override void EnterState()
    {
        _cts = new CancellationTokenSource();

        base.EnterState();

        AttackSequence(_cts.Token).Forget();
    }

    public override void ExitState()
    {
        base.ExitState();

        _cts?.Cancel();
        _cts?.Dispose();
    }
    public override void Tick()
    {
        if (_enemy.AnimationController.IsAnimationFinished())
            _stateMachine.SwitchState<EnemyChaseState>();
    }
    public async UniTask AttackSequence(CancellationToken token)
    {
        _enemy.AnimationController.PlayAnimation(GameConstant.EnemyAnimationData.ATTACK_HASH, GameConstant.AnimationSettings.QUICK_TRANSITION);

        var isCancelled = await UniTask.Delay(TimeSpan.FromSeconds(0.4f), cancellationToken: token).SuppressCancellationThrow();

        if(isCancelled) { return; }

        var target = _enemy.HasHitTarget();
        if (target != null)
            target.DecreaseHealthSequence();
    }

}
