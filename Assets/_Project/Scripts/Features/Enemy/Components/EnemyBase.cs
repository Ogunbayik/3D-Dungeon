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
    [Header("Attack Settings")]
    [SerializeField] private Transform _attackCheck;
    [SerializeField] private float _attackRadius;
    
    private float _movementSpeed;

    private Vector3 _initialPosition;

    [Inject]
    public void Construct(AnimationController animationController)
    {
        _animationController = animationController;

        _initialPosition = transform.position;
    }
    public AnimationController AnimationController => _animationController;
    public EnemyData Data => _data;
    public virtual void Start()
    {

    }
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
        var randomDistance = Random.Range(0, _data.PatrolDistance);
        var randomPosition = Random.insideUnitSphere;
        randomPosition.y = 0f;
        randomPosition.Normalize();

        var targetPosition = randomPosition * randomDistance;
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
    public PlayerHealthController HasHitTarget()
    {
        Collider[] hitColliders = new Collider[1];

        var targetCollider = Physics.OverlapSphereNonAlloc(_attackCheck.transform.position, _attackRadius, hitColliders, _checkLayer);

        if (targetCollider > 0)
        {
            return hitColliders[0].GetComponent<PlayerHealthController>();
        }
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

        //Attack distance for enemy
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(_attackCheck.transform.position, _attackRadius);
    }
}
