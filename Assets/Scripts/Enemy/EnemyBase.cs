using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] private float _checkRadius;
    [SerializeField] private LayerMask _checkLayer;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(transform.position, 2f);
    }

    public bool CheckPlayerInArea() => Physics.CheckSphere(transform.position, _checkRadius, _checkLayer);

}
