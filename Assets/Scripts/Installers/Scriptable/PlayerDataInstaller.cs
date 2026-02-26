using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "PlayerDataInstaller", menuName = "Installers/PlayerDataInstaller")]
public class PlayerDataInstaller : ScriptableObjectInstaller<PlayerDataInstaller>
{
    public PlayerData _playerData;
    public override void InstallBindings()
    {
        Container.BindInstance(_playerData).AsSingle();
    }
}