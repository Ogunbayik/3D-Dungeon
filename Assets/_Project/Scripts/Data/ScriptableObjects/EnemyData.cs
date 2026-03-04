using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Data", menuName = "SO/Enemy Data")]
public class EnemyData : BaseData
{
    [Header("Patrol Settings")]
    [SerializeField] private float _patrolDistance;
    [Header("Chase Settings")]
    [SerializeField] private float _chaseSpeed;
    [Header("Waiting Settings")]
    [SerializeField] private float _minWaitTime;
    [SerializeField] private float _maxWaitTime;
    [Header("Attack Settings")]
    [SerializeField] private float _attackDistance;

    public float PatrolDistance => _patrolDistance;
    public float ChaseSpeed => _chaseSpeed;
    public float MinWaitTime => _minWaitTime;
    public float MaxWaitTime => _maxWaitTime;
    public float AttackDistance => _attackDistance;
}
