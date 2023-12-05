using System;

namespace TeamB_TD
{
    namespace Battle
    {
        namespace StageManagement
        {
            [Serializable]
            [Flags]
            public enum StageCellStatus
            {
                None = 0, // デフォルト
                Movable = 1, // 敵ユニットが移動可能かどうか表現する。
                UnitPlaceable = 2, // 味方ユニットが配置可能かどうか表現する。
            }
        }
    }
}