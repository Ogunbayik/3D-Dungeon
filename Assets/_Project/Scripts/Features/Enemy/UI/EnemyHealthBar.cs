using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using DG.Tweening;

public class EnemyHealthBar : MonoBehaviour
{
    private EnemyBase _enemy;
    private EnemyHealthController _healthController;

    [Header("Health Bar Settings")]
    [SerializeField] private Image _fillImage;
    [Header("Decrease Settings")]
    [SerializeField] private float _decreaseDuration;
    [SerializeField] private float _fadeDuration;

    [Inject]
    public void Construct(EnemyBase enemy, EnemyHealthController healthController)
    {
        _enemy = enemy;
        _healthController = healthController;
    }
    private void Start() => Initialize();
    private void Initialize() => _fillImage.fillAmount = 1;
    private void OnEnable()
    {
        _healthController.OnHealthChanged += HealthController_OnHealthChanged;
        _healthController.OnDeath += HealthController_OnDeath;
    }
    private void OnDisable()
    {
        _healthController.OnHealthChanged -= HealthController_OnHealthChanged;
        _healthController.OnDeath -= HealthController_OnDeath;
    }
    private void HealthController_OnHealthChanged(int currentHealth)
    {
        float healthPercentage = (float)currentHealth / _enemy.Data.MaximumHealth;
        _fillImage.DOFillAmount(healthPercentage, _decreaseDuration);
    }
    private void HealthController_OnDeath() => DeathSequence();
    private void DeathSequence()
    {
        Sequence deathSequence = DOTween.Sequence();

        deathSequence.Append(_fillImage.DOFillAmount(0, _decreaseDuration));

        deathSequence.Append(_fillImage.DOFade(0, _fadeDuration));

        deathSequence.OnComplete(() => gameObject.SetActive(false));
    }

}
