using System;
using System.Collections.Generic;
using TeamB_TD.Battle.Unit.Enemy;
using UnityEngine;

namespace TeamB_TD
{
    namespace Battle
    {
        namespace StageManagement
        {
            [DefaultExecutionOrder(-100)]
            public class StageController : MonoBehaviour
            {
                private static StageController _current;
                public static StageController Current => _current;

                [SerializeField]
                private Stage _stage;
                [SerializeField]
                private int _stageID;
                [SerializeField]
                private SpawnerBlueprint _spawnerBlueprint;
                [SerializeField]
                private SpawnerData[] _spawnerData;

                private StageBlueprint _stageBlueprint = new StageBlueprint();

                public Stage Stage => _stage;
                public IReadOnlyList<EnemySpawner> enemySpawners => _spawnerBlueprint.Spawners;

                public event Action<IReadOnlyList<EnemySpawner>> OnCreatedSpawners;

                private void Awake()
                {
                    _current = this;

                    _stage.CreateStage(_stageBlueprint.GetStageData(_stageID));
                    foreach (var data in _spawnerData)
                    {
                        _spawnerBlueprint.AttachSpawnerToCell(_stage, data);
                    }
                    OnCreatedSpawners?.Invoke(_spawnerBlueprint.Spawners);
                }

                private void OnDestroy()
                {
                    _current = null;
                }

                public int GetNearestSpawnerCellLength(IStageCell startNode)
                {
                    return _stage.GetNearestSpawnerCellLength(startNode);
                }
            }
        }
    }
}