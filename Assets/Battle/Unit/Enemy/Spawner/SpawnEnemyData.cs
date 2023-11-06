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
                [Serializable]
                public struct SpawnEnemyData
                {
                    public SpawnEnemyData(int spawnEnemyID, float spawnTime)
                    {
                        _spawnEnemyID = spawnEnemyID;
                        _spawnTime = spawnTime;
                    }

                    [SerializeField]
                    private int _spawnEnemyID;
                    [SerializeField]
                    private float _spawnTime;

                    public int SpawnEnemyID => _spawnEnemyID;
                    public float SpawnTime => _spawnTime;
                }
            }
        }
    }
}