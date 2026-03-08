using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerHealthController : MonoBehaviour
{
    private PlayerBase _player;
    private SignalBus _signalBus;

    private int _currentHealth;

    [Inject]
    public void Construct(PlayerBase player, SignalBus signalBus)
    {
        _player = player;
        _signalBus = signalBus;
    }
    void Start() => Initialize();
    private void Initialize()
    {
        _currentHealth = _player.Data.MaximumHealth;
    }
    public void DecreaseHealthSequence()
    {
        _currentHealth--;

        _signalBus.Fire(new GameSignal.OnPlayerHealthChangedSignal(_currentHealth));

        if (_currentHealth <= 0)
            HandleDeath();
    }
    private void HandleDeath()
    {
        _currentHealth = 0;
        gameObject.layer = GameConstant.GameLayer.PLAYER_DEATH_LAYER;
        _signalBus.Fire(new GameSignal.OnPlayerModeChangedSignal(MyGame.Core.Enums.PlayerMode.Death));
    }
}
