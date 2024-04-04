using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject _pointA;
    public GameObject _pointB ;

    [field:SerializeField]
    public float speed { get; private set; }

    private Animator _animator;

    private Transform _currentPoint;

    internal Rigidbody2D _rb;

    public void OnPatrol()
    {
        Vector2 point = _currentPoint.position - transform.position;
        if (_currentPoint == _pointB.transform)
        {
            _rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            _rb.velocity = new Vector2(-speed, 0);
        }

        if (Vector2.Distance(transform.position, _currentPoint.position) < 0.5f && _currentPoint == _pointB.transform)
        {
            _currentPoint = _pointA.transform;
        }
        if (Vector2.Distance(transform.position, _currentPoint.position) < 0.5f && _currentPoint == _pointA.transform)
        {
            _currentPoint = _pointB.transform;
        }
    }

    private void Update()
    {
        OnPatrol();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(_pointA.transform.position, 0.4f);
        Gizmos.DrawWireSphere   (_pointB.transform.position, 0.4f);
        Gizmos.DrawLine(_pointA.transform.position, _pointB.transform.position);
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _currentPoint = _pointB.transform;
        _animator.SetBool("IsPatrolling", true);
    }
}
