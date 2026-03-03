using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Data", menuName = "SO/Enemy Data")]
public class EnemyData : BaseData
{
    [Header("Patrol Settings")]
    [SerializeField] private float _patrolDistance;

    public float PatrolDistance => _patrolDistance;
}
