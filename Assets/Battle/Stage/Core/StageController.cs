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
                    _stage.CreateStage(_stageBlueprint.GetStageData(_stageID));
                    foreach (var data in _spawnerData)
                    {
                        _spawnerBlueprint.AttachSpawnerToCell(_stage, data);
                    }
                    OnCreatedSpawners?.Invoke(_spawnerBlueprint.Spawners);
                }
            }
        }
    }
}