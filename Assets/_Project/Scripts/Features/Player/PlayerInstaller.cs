using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<PlayerBase>().FromComponentOnRoot().AsSingle();
        Container.Bind<PlayerHealthController>().FromComponentOnRoot().AsSingle();

        Container.Bind<Animator>().FromComponentInHierarchy().AsSingle();
        Container.Bind<AnimationController>().AsSingle();

        Container.Bind<IState>().To<PlayerIdleState>().AsSingle();
        Container.Bind<IState>().To<PlayerMovementState>().AsSingle();
        Container.Bind<IState>().To<PlayerAirborneState>().AsSingle();
        Container.Bind<IState>().To<PlayerAttackState>().AsSingle();

        Container.BindInterfacesAndSelfTo<PlayerStateMachine>().AsSingle().NonLazy();
    }
}