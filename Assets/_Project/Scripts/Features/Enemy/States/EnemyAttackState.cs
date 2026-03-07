using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Zenject;

public class EnemyAttackState : EnemyBaseState
{
    private CancellationTokenSource _cts;

    private SignalBus _signalBus;

    public EnemyAttackState(SignalBus signalBus,EnemyBase enemy, EnemyHealthController healthController) : base(enemy, healthController) 
    {
        _signalBus = signalBus;
    }

    public override void EnterState()
    {
        _cts = new CancellationTokenSource();

        base.EnterState();

        AttackSequence(_cts.Token).Forget();

        _signalBus.Subscribe<GameSignal.OnPlayerModeChangedSignal>(OnPlayerDeath);
    }

    public override void ExitState()
    {
        base.ExitState();

        _cts?.Cancel();
        _cts?.Dispose();
        _signalBus.Unsubscribe<GameSignal.OnPlayerModeChangedSignal>(OnPlayerDeath);
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
