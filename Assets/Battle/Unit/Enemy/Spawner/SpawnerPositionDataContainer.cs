using TeamB_TD.Utility;
using UnityEngine;
using System;

namespace TeamB_TD
{
    namespace Battle
    {
        namespace Unit
        {
            namespace Enemy
            {
                public class SpawnerPositionDataContainer
                {
                    // データは配列で管理する。
                    // IndexとIDは同義として扱う。

                    private SpawnerPositionData[] _positionData =
                    {
                        // 注意事項: Vector2Int型のコンストラクタは第一引数がx,第二引数がy座標を表現する。 
                        new SpawnerPositionData(new Vector2Int(0, 0), new Vector2Int(6, 0)), // スポナーの座標x0,y0、タワーの座標x3,y0。
                        new SpawnerPositionData(new Vector2Int(0, 0), new Vector2Int(6, 0)),
                        new SpawnerPositionData(new Vector2Int(0, 2), new Vector2Int(15, 2)), // 2
                        new SpawnerPositionData(new Vector2Int(0, 3), new Vector2Int(15, 3)), // 3
                        new SpawnerPositionData(new Vector2Int(0, 4), new Vector2Int(15, 4)), // 4
                        new SpawnerPositionData(new Vector2Int(0, 5), new Vector2Int(15, 5)), // 5
                        new SpawnerPositionData(new Vector2Int(0, 6), new Vector2Int(15, 6)), // 6
                        new SpawnerPositionData(new Vector2Int(0, 7), new Vector2Int(15, 7)), // 5
                    };

                    public SpawnerPositionData GetSpawnerPositionData(int id)
                    {
                        if (!_positionData.IsIndexInRange(id))
                            throw new ArgumentOutOfRangeException(nameof(id));

                        return _positionData[id];
                    }
                }
            }
        }
    }
}