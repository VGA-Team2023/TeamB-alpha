using System;

namespace TeamB_TD
{
    namespace Utility
    {
        public static class ArrayUtility
        {
            public static bool IsIndexInRange(this Array array, int index)
            {
                if (array == null)
                {
                    // 配列がnullの場合、インデックスは範囲外
                    return false;
                }

                // インデックスが0未満または配列の長さ以上の場合、範囲外
                return index >= 0 && index < array.Length;
            }
        }
    }
}