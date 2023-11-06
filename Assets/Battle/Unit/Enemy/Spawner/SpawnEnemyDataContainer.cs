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
                public class SpawnEnemyDataContainer
                {
                    // データは配列で管理する。
                    // IndexとIDは同義として扱う。

                    private SpawnEnemyData[][] _spawnData = // 全てのスポーンデータ
                    {
                        new SpawnEnemyData[] // 一スポナー分のデータ
                        {
                            new SpawnEnemyData(0,1f) , // 一体分のデータ（例: EnemyID 0をバトル開始後 1秒後に生成する。）
                            new SpawnEnemyData(1,2f) , // （例: EnemyID 1をバトル開始後 2秒後に生成する。）
                            new SpawnEnemyData(2,3f) , // （例: EnemyID 2をバトル開始後 3秒後に生成する。）
                            new SpawnEnemyData(3,4f) , // （例: EnemyID 3をバトル開始後 4秒後に生成する。）
                        },
                    };

                    public SpawnEnemyData[] GetSpawnData(int id)
                    {
                        if (!ArrayUtility.IsIndexInRange(_spawnData, id))
                            throw new ArgumentOutOfRangeException(nameof(id));

                        return _spawnData[id];
                    }
                }
            }
        }
    }
}