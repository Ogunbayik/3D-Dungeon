using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemyHealthController : MonoBehaviour
{
    private EnemyBase _enemy;

    public event Action<int> OnHealthChanged;
    public event Action OnDeath;

    private int _currentHealth;

    [Inject]
    public void Construct(EnemyBase enemy) => _enemy = enemy;
    private void Start() => Initialize();
    private void Initialize()
    {
        _currentHealth = _enemy.Data.MaximumHealth;
    }
    public void TakeDamage(int damageAmount)
    {
        _currentHealth -= damageAmount;

        if(_currentHealth <= 0)
        {
            _currentHealth = 0;
            OnDeath?.Invoke();
            return;
        }

        OnHealthChanged?.Invoke(_currentHealth);
    }
}
