using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Data", menuName = "SO/Player Data")]
public class PlayerData : ScriptableObject
{
    [Header("Movement Settings")]
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _rotationSpeed;
    [Header("Jump Settings")]
    [SerializeField] private float _jumpHeight;
    [SerializeField] private float _gravityMultiplier;
    [SerializeField] private float _groundedGravity;


    public float MovementSpeed => _movementSpeed;
    public float RotationSpeed => _rotationSpeed;
    public float JumpHeight => _jumpHeight;
    public float GravityMultiplier => _gravityMultiplier;
    public float GroundedGravity => _groundedGravity;
}
