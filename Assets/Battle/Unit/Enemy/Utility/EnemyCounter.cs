using System;
using System.Collections.Generic;
using TeamB_TD.Battle.StageManagement;
using UnityEngine;

namespace TeamB_TD
{
    namespace Battle
    {
        namespace Unit
        {
            namespace Enemy
            {
                public class EnemyCounter : MonoBehaviour
                {
                    private static EnemyCounter _current;
                    public static EnemyCounter Current => _current;

                    [SerializeField]
                    private StageController _stageController;

                    private int _enemyCount = 0; // 敵の全体数。
                    private int _deadEnemyCount = 0; // 死んだ敵の数。
                    private int _towerInvasionCount = 0; // タワーに侵入した敵の数。

                    public int EnemyCount => _enemyCount;
                    public int DeadEnemyCount => _deadEnemyCount;
                    public int TowerInvasionCount => _towerInvasionCount;
                    /// <summary> 行動完了した敵の数を表現する値。 </summary>
                    public int CompletedEnemyCount => _deadEnemyCount + _towerInvasionCount;

                    public event Action<int> OnDeadEnemyCountChanged;
                    public event Action<int> OnTowerInvasionCountChanged;
                    public event Action<int> OnCompletedEnemyCountChanged;

                    private void Awake()
                    {
                        _current = this;
                    }

                    private void Start()
                    {
                        _enemyCount = GetEnemyCount(_stageController.enemySpawners);
                    }

                    public int GetEnemyCount(IEnumerable<EnemySpawner> enemySpawners)
                    {
                        var count = 0;
                        foreach (var spawner in enemySpawners)
                        {
                            count += spawner.EnemyCount;
                        }
                        return count;
                    }

                    public void OnEnemyDead() // Enemyが死んだ時に呼び出す。
                    {
                        _deadEnemyCount++;
                        OnDeadEnemyCountChanged?.Invoke(_deadEnemyCount);
                        OnCompletedEnemyCountChanged?.Invoke(CompletedEnemyCount);
                    }

                    public void OnTowerInvasion() // Enemyがタワーに到着したときに呼び出す。
                    {
                        _towerInvasionCount++;
                        OnTowerInvasionCountChanged?.Invoke(_towerInvasionCount);
                        OnCompletedEnemyCountChanged?.Invoke(CompletedEnemyCount);
                    }
                }
            }
        }
    }
}