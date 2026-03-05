using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    public event Action<int> OnHealthChanged;
    public event Action OnDeath;

    public int _maxHealth;

    private int _currentHealth;

    private void Start() => Initialize();
    private void Initialize()
    {
        _currentHealth = _maxHealth;
    }
    public void TakeDamage(int damageAmount)
    {
        _currentHealth -= damageAmount;

        OnHealthChanged?.Invoke(_currentHealth);

        if(_currentHealth <= 0)
        {
            _currentHealth = 0;
            OnDeath?.Invoke();
        }
    }
}
