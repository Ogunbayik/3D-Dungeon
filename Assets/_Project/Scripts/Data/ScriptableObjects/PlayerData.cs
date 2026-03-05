using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Data", menuName = "SO/Player Data")]
public class PlayerData : BaseData
{
    [Header("Jump Settings")]
    [SerializeField] private float _jumpHeight;
    [SerializeField] private float _gravityMultiplier;
    [SerializeField] private float _groundedGravity;
    [Header("Attack Settings")]
    [SerializeField] private float _attackCheckTime;
    [SerializeField] private int _attackDamage;
    
    public float JumpHeight => _jumpHeight;
    public float GravityMultiplier => _gravityMultiplier;
    public float GroundedGravity => _groundedGravity;
    public float AttackCheckTime => _attackCheckTime;
    public int AttackDamage => _attackDamage;

}
