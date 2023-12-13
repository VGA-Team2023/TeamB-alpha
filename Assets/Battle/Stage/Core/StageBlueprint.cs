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
                        {0, 0, 0, 0, 2, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0},
                        {0, 0, 0, 1, 1, 1, 1, 1, 3, 1, 1, 1, 0, 0, 0, 0},
                        {0, 1, 1, 1, 3, 1, 0, 2, 0, 0, 0, 1, 1, 3, 1, 1},
                        {0, 1, 1, 1, 2, 0, 0, 0, 0, 0, 0, 1, 1, 3, 1, 0},
                        {0, 1, 1, 1, 3, 1, 0, 0, 0, 2, 0, 1, 1, 3, 1, 1},
                        {0, 0, 0, 1, 1, 1, 1, 1, 1, 3, 1, 1, 0, 0, 0, 0},
                        {0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0},
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