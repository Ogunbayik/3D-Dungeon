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
    public float GetWaitTime() => Random.Range(_data.MinWaitTime, _data.MaxWaitTime);
    public PlayerBase CheckPlayerInArea()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, _checkRadius, _checkLayer);

        if (hitColliders.Length > 0)
            return hitColliders[0].transform.GetComponent<PlayerBase>();
        else
            return null;
    }
    private void OnDrawGizmos()
    {
        //Check Distance for Player
        Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(transform.position, _checkRadius);

        //Patrol distance for Enemy
        Gizmos.color = Color.blue;

        Gizmos.DrawWireSphere(_initialPosition, _data.PatrolDistance);
    }
}
