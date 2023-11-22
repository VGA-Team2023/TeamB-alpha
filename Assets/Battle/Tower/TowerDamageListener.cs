using System.Collections;
using System.Collections.Generic;
using TeamB_TD.Battle.Unit.Enemy;
using TeamB_TD.Battle.Tower;
using UnityEngine;

// 日本語対応
[RequireComponent(typeof(Rigidbody2D))]
public class TowerDamageListener : MonoBehaviour
{
    /// <summary>このセルに入ってきた敵を格納する</summary>
    private List<EnemyController> _enemyList = new List<EnemyController>(4);
    /// <summary>1度処理を行った敵を格納する(繰り返し同じ敵に同じ処理を行わないために)</summary>
    private HashSet<EnemyController> _completed = new HashSet<EnemyController>();

    private void Start()
    {
        if (!TryGetComponent(out Rigidbody2D rb2d)) return;
        rb2d.isKinematic = true;
    }

    private void Update()
    {
        InvadedByEnemy();
    }

    private void InvadedByEnemy()
    {
        if (_enemyList.Count <= 0) return;

        for (int i = 0; i < _enemyList.Count; i++)
        {
            var enemy = _enemyList[i];
            if (enemy == null) continue;
            if (_completed.Contains(enemy)) continue;
            if (Vector3.Distance(enemy.transform.position, transform.position) > 0.1f) continue;

            TowerController.Instance.Damage();
            _enemyList.RemoveAt(i);
            _completed.Add(enemy);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out EnemyController enemy))
        {
            _enemyList.Add(enemy);
        }
    }
}
