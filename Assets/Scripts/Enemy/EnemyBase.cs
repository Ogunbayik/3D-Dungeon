using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [Header("Data References")]
    [SerializeField] private EnemyData _data;
    [Header("Check Settings")]
    [SerializeField] private float _checkRadius;
    [SerializeField] private LayerMask _checkLayer;
    
    private float _movementSpeed;

    private Vector3 _initialPosition;

    public EnemyData Data => _data;
    void Start() => _initialPosition = transform.position;
    public void MoveTo(Vector3 targetPosition) => transform.position = Vector3.MoveTowards(transform.position, targetPosition, _movementSpeed * Time.deltaTime);
    public void SetMovementSpeed(float speed)
    {
        if (_movementSpeed == speed) return;

        _movementSpeed = speed;
    }
    public Vector3 GetPatrolPosition()
    {
        var randomPosition = Random.insideUnitSphere;

        var targetPosition = new Vector3(randomPosition.x, 0f, randomPosition.z) * _data.PatrolDistance;
        return _initialPosition + targetPosition;
    }
    public bool CheckPlayerInArea() => Physics.CheckSphere(transform.position, _checkRadius, _checkLayer);
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(transform.position, 2f);
    }
}
