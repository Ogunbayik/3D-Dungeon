using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class PlayerHealthDisplay : MonoBehaviour
{
    private SignalBus _signalBus;

    [Header("Image References")]
    [SerializeField] private List<Image> _hearts = new List<Image>();
    [Header("Sprite References")]
    [SerializeField] private Sprite _heartFull;
    [SerializeField] private Sprite _heartEmpty;

    [Inject]
    public void Construct(SignalBus signalBus) => _signalBus = signalBus;
    void Start() => Initialize();
    private void Initialize()
    {
        for (int i = 0; i < _hearts.Count; i++)
            _hearts[i].sprite = _heartFull;
    }
    private void OnEnable() => _signalBus.Subscribe<GameSignal.OnPlayerHealthChangedSignal>(OnHealthChanged);
    private void OnDisable() => _signalBus.Unsubscribe<GameSignal.OnPlayerHealthChangedSignal>(OnHealthChanged);
    public void OnHealthChanged(GameSignal.OnPlayerHealthChangedSignal signal) => _hearts[signal.CurrentHealthCount].sprite = _heartEmpty;


}
