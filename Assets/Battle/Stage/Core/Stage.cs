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
            [Serializable]
            public class Stage
            {
                [SerializeField]
                private StageCell _cellPrefab;
                [SerializeField]
                private Transform _cellParent;

                private IStageCell[,] _stageData = null;
                public IStageCell[,] StageData => _stageData;

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

                    float xOffset = (_stageData[0, width - 1].GameObject.transform.position.x - _stageData[0, 0].GameObject.transform.position.x) / 2f;
                    float yOffset = (_stageData[height - 1, 0].GameObject.transform.position.y - _stageData[0, 0].GameObject.transform.position.y) / 2f;

                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            _stageData[y, x].GameObject.transform.position -= new Vector3(xOffset, yOffset, 0f);
                        }
                    }
                }

                public bool TryGetCell(out IStageCell cell, int y, int x)
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

                public int GetNearestSpawnerCellLength(IStageCell startNode)
                {
                    IStageCell[,] nodeGraph = _stageData;
                    HashSet<IStageCell> spawnerCells = EnemySpawnerManager.Current.SpawnerCells;

                    Queue<IStageCell> queue = new Queue<IStageCell>();
                    HashSet<IStageCell> visited = new HashSet<IStageCell>() { startNode };
                    List<IStageCell> adjacencyList = new List<IStageCell>();
                    int currentDepth = 1;

                    queue.Enqueue(startNode);
                    while (queue.Count != 0)
                    {
                        int nodesAtCurrentDepth = queue.Count; // 現在の深さにあるノードの数を記録
                        for (int i = 0; i < nodesAtCurrentDepth; i++)
                        {
                            var node = queue.Dequeue();

                            adjacencyList.Clear();
                            if (TryGetCell(out IStageCell top, node.YPos + 1, node.XPos))
                                adjacencyList.Add(top);
                            if (TryGetCell(out IStageCell bottom, node.YPos - 1, node.XPos))
                                adjacencyList.Add(bottom);
                            if (TryGetCell(out IStageCell right, node.YPos, node.XPos + 1))
                                adjacencyList.Add(right);
                            if (TryGetCell(out IStageCell left, node.YPos, node.XPos - 1))
                                adjacencyList.Add(left);

                            foreach (var adjacency in adjacencyList)
                            {
                                if (!visited.Contains(adjacency))
                                {
                                    if (spawnerCells.Contains(adjacency))
                                    {
                                        return currentDepth;
                                    }

                                    visited.Add(adjacency);
                                    queue.Enqueue(adjacency);
                                }
                            }
                        }

                        currentDepth++; // 深さを増加させる
                    }

                    return -1;
                }
            }
        }
    }
}