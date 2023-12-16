using System;
using TeamB_TD.Utility;

namespace TeamB_TD
{
    namespace Battle
    {
        namespace StageManagement
        {
            public class StageBlueprint
            {
                private int[][,] _stageBlueprints =
                {
                        new int[,]{ // Stage1[id:0]
                        { 0, 0, 2, 0, 2, 0, 2, 0, 0 },
                        { 1, 1, 3, 1, 3, 1, 3, 1, 1 },
                        { 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                        { 1, 1, 3, 1, 3, 1, 3, 1, 1 },
                        { 0, 0, 2, 0, 2, 0, 2, 0, 0 },
                        },
                        new int[,]{ // Stage2[id:1]
                       //0  1  2  3  4  5  6  7  8  9  10 11 12 13 14 15
                        {0, 0, 0, 0, 2, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0}, // 0
                        {0, 0, 0, 1, 1, 1, 1, 1, 3, 1, 1, 1, 0, 0, 0, 0}, // 1
                        {0, 1, 1, 1, 3, 1, 0, 2, 0, 0, 0, 1, 1, 3, 1, 1}, // 2
                        {0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 1, 1, 3, 1, 0}, // 3
                        {0, 1, 1, 1, 3, 1, 0, 0, 0, 2, 0, 1, 1, 3, 1, 1}, // 4
                        {0, 0, 0, 1, 1, 1, 1, 1, 1, 3, 1, 1, 0, 0, 0, 0}, // 5
                        {0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0}, // 6
                        },
                        new int[,]{ // Stage3[id:2]
                        {2, 1, 1, 1, 1, 1},
                        {1, 0, 0, 0, 0, 1},
                        {1, 1, 1, 1, 1, 1},
                        {1, 0, 0, 1, 0, 1},
                        {1, 0, 0, 1, 0, 1},
                        {1, 1, 1, 1, 1, 3},
                        },
                    };

                public int[,] GetStageData(int stageNumber)
                {
                    if (!ArrayUtility.IsIndexInRange(_stageBlueprints, stageNumber))
                        throw new ArgumentOutOfRangeException(nameof(stageNumber));

                    return _stageBlueprints[stageNumber];
                }
            }
        }
    }
}