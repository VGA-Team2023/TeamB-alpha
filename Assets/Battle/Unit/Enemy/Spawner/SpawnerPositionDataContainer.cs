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
                        new SpawnerPositionData(new Vector2Int(0, 1), new Vector2Int(6, 1)),
                        new SpawnerPositionData(new Vector2Int(0, 2), new Vector2Int(6, 2)),
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