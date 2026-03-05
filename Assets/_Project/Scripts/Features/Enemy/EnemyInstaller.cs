using UnityEngine;
using Zenject;

public class EnemyInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<EnemyBase>().FromComponentOnRoot().AsSingle();
        Container.Bind<EnemyHealthController>().FromComponentOnRoot().AsSingle();

        Container.Bind<Animator>().FromComponentInHierarchy().AsSingle();
        Container.Bind<AnimationController>().AsSingle();

        Container.Bind<IState>().To<EnemyPatrolState>().AsSingle();
        Container.Bind<IState>().To<EnemyChaseState>().AsSingle();
        Container.Bind<IState>().To<EnemyWaitState>().AsSingle();
        Container.Bind<IState>().To<EnemyAttackState>().AsSingle();

        Container.BindInterfacesAndSelfTo<EnemyStateMachine>().AsSingle().NonLazy();
    }
}