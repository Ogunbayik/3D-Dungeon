using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerHealthController : MonoBehaviour
{
    private SignalBus _signalBus;

    public int HealthCount;

    private float _currentHealth;

    [Inject]
    public void Construct(SignalBus signalBus) => _signalBus = signalBus;
    void Start() => Initialize();
    private void Initialize()
    {
        _currentHealth = HealthCount;
    }
    public void DecreaseHealthSequence()
    {
        //TODO Animasyon ile Player'ýn can azaltýlacak ve UI güncellenecek
        _currentHealth--;

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
