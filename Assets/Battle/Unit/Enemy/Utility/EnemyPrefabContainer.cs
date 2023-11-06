using System;
using TeamB_TD.Utility;
using UnityEngine;

namespace TeamB_TD
{
    namespace Battle
    {
        namespace Unit
        {
            namespace Enemy
            {
                [CreateAssetMenu]
                public class EnemyPrefabContainer : ScriptableObject
                {
                    // Enemyデータは配列で管理するモノとする。
                    // IndexとIDは同義として扱う。

                    [SerializeField]
                    private EnemyController[] _enemyPrefabs;

                    public EnemyController GetEnemyPrefab(int id)
                    {
                        if (!ArrayUtility.IsIndexInRange(_enemyPrefabs, id))
                            throw new ArgumentOutOfRangeException(nameof(id));

                        return _enemyPrefabs[id];
                    }
                }
            }
        }
    }
}