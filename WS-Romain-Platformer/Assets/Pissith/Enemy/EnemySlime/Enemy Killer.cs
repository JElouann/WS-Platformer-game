using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EnemyKiller : MonoBehaviour
{
    private EnemyMain _enemyMain;

    [SerializeField]
    private float _fling;

    private void Start()
    {
        _fling = 20f;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyMovement _enemy = collision.gameObject.GetComponent<EnemyMovement>();
            _enemy.enabled = false;
            _enemy._rb.constraints = RigidbodyConstraints2D.None;
            _enemy._rb.AddForce(new Vector2(1,1) * _fling, ForceMode2D.Impulse);
            _enemy.transform.DORotate(new Vector3 (0, 0, 270f), 0.1f);
        }
    }
}
