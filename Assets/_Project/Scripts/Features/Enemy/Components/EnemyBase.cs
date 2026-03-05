using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemyBase : MonoBehaviour
{
    private AnimationController _animationController;

    [Header("Data References")]
    [SerializeField] private EnemyData _data;
    [SerializeField] private Transform _enemyVisual;
    [Header("Check Settings")]
    [SerializeField] private float _checkRadius;
    [SerializeField] private LayerMask _checkLayer;
    
    private float _movementSpeed;

    private Vector3 _initialPosition;

    [Inject]
    public void Construct(AnimationController animationController) => _animationController = animationController;

    public AnimationController AnimationController => _animationController;
    public EnemyData Data => _data;
    void Start() => _initialPosition = transform.position;
    public void MoveTo(Vector3 targetPosition)
    {
        targetPosition.y = 0f;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, _movementSpeed * Time.deltaTime);
    }
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
    public void HandleRotation(Vector3 targetPosition)
    {
        Vector3 targetDirection = (targetPosition - transform.position).normalized;
        targetDirection.y = 0f;

        if (targetDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            _enemyVisual.rotation = Quaternion.Slerp(_enemyVisual.rotation, targetRotation, _data.RotationSpeed * Time.deltaTime);
        }
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
