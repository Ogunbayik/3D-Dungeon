using UnityEngine;
using Zenject;

public class SignalInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);

        Container.DeclareSignal<GameSignal.OnPlayerModeChangedSignal>();
        Container.DeclareSignal<GameSignal.OnPlayerHealthChangedSignal>();

        Container.BindSignal<GameSignal.OnPlayerModeChangedSignal>()
            .ToMethod<CameraManager>(x => x.ToggleCamera)
            .FromResolve();
    }
}