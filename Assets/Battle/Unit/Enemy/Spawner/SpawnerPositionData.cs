using System;
using UnityEngine;

namespace TeamB_TD
{
    namespace Battle
    {
        namespace Unit
        {
            namespace Enemy
            {
                public struct SpawnerPositionData
                {
                    public SpawnerPositionData(Vector2Int spawnerPosition, Vector2Int goalPosition)
                    {
                        _spawnerPosition = spawnerPosition;
                        _goalPosition = goalPosition;
                    }

                    private Vector2Int _spawnerPosition;
                    private Vector2Int _goalPosition;

                    public Vector2Int SpawnerPosition => _spawnerPosition;
                    public Vector2Int GoalPosition => _goalPosition;
                }
            }
        }
    }
}