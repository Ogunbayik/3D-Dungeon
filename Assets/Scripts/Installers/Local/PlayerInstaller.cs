using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<PlayerController>().FromComponentOnRoot().AsSingle();
        Container.Bind<Animator>().FromComponentInHierarchy().AsSingle();
        Container.Bind<PlayerAnimationController>().AsSingle();

        Container.Bind<IState>().To<PlayerIdleState>().AsSingle();
        Container.Bind<IState>().To<PlayerMovementState>().AsSingle();
        Container.Bind<IState>().To<PlayerAirborneState>().AsSingle();

        Container.BindInterfacesAndSelfTo<StateMachine>().AsSingle().NonLazy();
    }
}