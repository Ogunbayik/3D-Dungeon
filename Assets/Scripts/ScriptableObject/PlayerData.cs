using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Data", menuName = "SO/Player Data")]
public class PlayerData : ScriptableObject
{
    [Header("Movement Settings")]
    [SerializeField] private float _movementSpeed;



    public float MovementSpeed => _movementSpeed;
}
