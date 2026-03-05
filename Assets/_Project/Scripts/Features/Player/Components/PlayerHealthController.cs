using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public int HealthCount;

    private float _currentHealth;
    void Start() => Initialize();
    private void Initialize()
    {
        _currentHealth = HealthCount;
    }
    public void DecreaseHealthSequence()
    {
        //TODO Animasyon ile Player'ýn can azaltýlacak ve UI güncellenecek
        Debug.Log("Decrease Player Health");
    }
}
