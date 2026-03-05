using Cysharp.Threading.Tasks;
using System;
using System.Diagnostics;
using System.Threading;

public class PlayerAttackState : PlayerGroundedState
{
    private CancellationTokenSource _cts;
    public PlayerAttackState(PlayerBase player, PlayerHealthController healthController) : base(player, healthController) { }
    public override void EnterState()
    {
        base.EnterState();
        _cts = new CancellationTokenSource();
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
        if (_player.AnimationControler.IsAnimationFinished())
            _stateMachine.SwitchState<PlayerIdleState>();
    }
    public async UniTask AttackSequence(CancellationToken token)
    {
        _player.AnimationControler.PlayAnimation(GameConstant.PlayerAnimationData.ATTACK_HASH, GameConstant.AnimationSettings.QUICK_TRANSITION);

        bool isCanceled = await UniTask.Delay(TimeSpan.FromSeconds(_player.Data.AttackCheckTime), cancellationToken: token)
                                       .SuppressCancellationThrow();

        if(isCanceled) { return; }

        var target = _player.HasValidTarget();
        if (target != null)
            target.TakeDamage(_player.Data.AttackDamage);
    }

}
