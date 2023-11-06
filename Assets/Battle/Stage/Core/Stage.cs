using System;
using UnityEngine;

namespace TeamB_TD
{
    namespace Battle
    {
        namespace StageManagement
        {
            [Serializable]
            public class Stage
            {
                [SerializeField]
                private StageCell _cellPrefab;
                [SerializeField]
                private Transform _cellParent;

                private StageCell[,] _stageData = null;
                public StageCell[,] StageData => _stageData;

                public void CreateStage(int[,] stageBlueprint)
                {
                    var height = stageBlueprint.GetLength(0);
                    var width = stageBlueprint.GetLength(1);
                    _stageData = new StageCell[height, width];

                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            var stageCell = GameObject.Instantiate(_cellPrefab, _cellParent);
                            stageCell.Initialize(stageBlueprint[y, x], y, x);
                            stageCell.gameObject.name = $"Stage Cell y: {y}, x: {x}";
                            _stageData[y, x] = stageCell;
                        }
                    }
                }

                public bool TryGetCell(out StageCell cell, int y, int x)
                {
                    cell = null;

                    if (_stageData == null)
                        return false;

                    if (y < 0 || x < 0 ||
                        y >= _stageData.GetLength(0) ||
                        x >= _stageData.GetLength(1))
                        return false;

                    cell = _stageData[y, x];
                    return cell != null;
                }
            }
        }
    }
}