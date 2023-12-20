using System;
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
                public class EnemySpawner : MonoBehaviour
                {
                    private EnemyPrefabContainer _enemyPrefabContainer;
                    private Stage _stage; // 経路探索用
                    private IStageCell _spawnerCell; // スポナーを配置するセル。
                    private IStageCell _goalCell; // 目的地。敵はここに向かって移動する。
                    private SpawnEnemyData[] _spawnData; // 敵の生成に関する情報。

                    public int EnemyCount => _spawnData != null ? _spawnData.Length : 0;

                    public void Initialize(EnemyPrefabContainer enemyPrefabContainer,
                        Stage stage, IStageCell spawnerCell, IStageCell goalCell, SpawnEnemyData[] spawnData)
                    {
                        _enemyPrefabContainer = enemyPrefabContainer;
                        _stage = stage;
                        _spawnerCell = spawnerCell;
                        _goalCell = goalCell;
                        _spawnData = spawnData;

                        Array.Sort(_spawnData, (data1, data2) => data1.SpawnTime.CompareTo(data2.SpawnTime));
                    }

                    private int _index = 0;
                    private float _spawnTimer = 0f;

                    private void Update()
                    {
                        if (_index < 0 || _index >= _spawnData.Length) return;

                        if (!_enemyPrefabContainer) return;

                        _spawnTimer += Time.deltaTime * GameSpeedController.CurretGameSpeed;

                        if (_spawnTimer >= _spawnData[_index].SpawnTime)
                        {
                            var enemyID = _spawnData[_index].SpawnEnemyID;
                            var enemyPrefab = _enemyPrefabContainer.GetEnemyPrefab(enemyID);
                            if (!enemyPrefab)
                            {
                                Debug.Log("Enemy Prefabの取得に失敗。");
                                return;
                            }
                            Spawn(enemyPrefab);
                            
                            
                            _index++;
                        }
                    }

                    private void Spawn(EnemyController enemyPrefab)
                    {
                        var enemy = GameObject.Instantiate(enemyPrefab);
                        enemy.Initialize(_stage, _spawnerCell, _goalCell);
                        // Debug.Log($"spawned enemy is {enemy.gameObject.name}");
                    }
                }
            }
        }
    }
}