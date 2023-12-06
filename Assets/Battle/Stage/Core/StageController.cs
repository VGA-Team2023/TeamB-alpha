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

                public IStageCell GetNearestSpawnerCell(IStageCell startNode) // 四近傍の中で最もスポナーに近いセルを取得する。
                {
                    int minLength = int.MaxValue;
                    IStageCell nearestSpawnerCell = null;
                    if (Stage.TryGetCell(out IStageCell top, startNode.YPos + 1, startNode.XPos))
                    {
                        var len = GetNearestSpawnerCellLength(top);
                        if (len != -1 && minLength > len) { minLength = len; nearestSpawnerCell = top; }
                    }
                    if (Stage.TryGetCell(out IStageCell bottom, startNode.YPos - 1, startNode.XPos))
                    {
                        var len = GetNearestSpawnerCellLength(bottom);
                        if (len != -1 && minLength > len) { minLength = len; nearestSpawnerCell = bottom; }
                    }
                    if (Stage.TryGetCell(out IStageCell right, startNode.YPos, startNode.XPos + 1))
                    {
                        var len = GetNearestSpawnerCellLength(right);
                        if (len != -1 && minLength > len) { minLength = len; nearestSpawnerCell = right; }
                    }
                    if (Stage.TryGetCell(out IStageCell left, startNode.YPos, startNode.XPos - 1))
                    {
                        var len = GetNearestSpawnerCellLength(left);
                        if (len != -1 && minLength > len) { minLength = len; nearestSpawnerCell = left; }
                    }

                    return nearestSpawnerCell;
                }
            }
        }
    }
}