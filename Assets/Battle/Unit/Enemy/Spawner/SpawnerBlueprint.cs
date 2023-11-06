using UnityEngine;
using System;
using TeamB_TD.Battle.StageManagement;
using System.Collections.Generic;

namespace TeamB_TD
{
    namespace Battle
    {
        namespace Unit
        {
            namespace Enemy
            {
                public class SpawnerBlueprint : MonoBehaviour
                {
                    [SerializeField]
                    private EnemyPrefabContainer _enemyPrefabContainer;

                    private readonly List<EnemySpawner> _currents = new List<EnemySpawner>();

                    private SpawnerPositionDataContainer _spawnPositionDataContainer = new SpawnerPositionDataContainer();
                    private SpawnEnemyDataContainer _spawnEnemyDataContainer = new SpawnEnemyDataContainer();

                    public IReadOnlyList<EnemySpawner> Spawners => _currents;

                    public void AttachSpawnerToCell(Stage stage, SpawnerData spawnerData)
                    {
                        var spawnerPositionID = spawnerData.SpawnerPositionID;
                        var positionData = _spawnPositionDataContainer.GetSpawnerPositionData(spawnerPositionID);

                        var spawnerPos = positionData.SpawnerPosition;
                        if (!stage.TryGetCell(out StageCell spawnerCell, spawnerPos.y, spawnerPos.x))
                            throw new ArgumentOutOfRangeException(nameof(spawnerPos));

                        var gorlPos = positionData.GoalPosition;
                        if (!stage.TryGetCell(out StageCell gorlCell, gorlPos.y, gorlPos.x))
                            throw new ArgumentOutOfRangeException(nameof(gorlPos));

                        var spawnEnemyDataID = spawnerData.SpawnEnemyDataID;
                        var enemySpawnData = _spawnEnemyDataContainer.GetSpawnData(spawnEnemyDataID);

                        var spawnerComponent = spawnerCell.gameObject.AddComponent<EnemySpawner>();
                        spawnerComponent.Initialize(_enemyPrefabContainer, stage, spawnerCell, gorlCell, enemySpawnData);
                        _currents.Add(spawnerComponent);
                    }
                }

                [Serializable]
                public struct SpawnerData
                {
                    [SerializeField]
                    private int _spawnEnemyDataID;
                    [SerializeField]
                    private int _spawnerPositionID;

                    public int SpawnEnemyDataID => _spawnEnemyDataID;
                    public int SpawnerPositionID => _spawnerPositionID;
                }
            }
        }
    }
}