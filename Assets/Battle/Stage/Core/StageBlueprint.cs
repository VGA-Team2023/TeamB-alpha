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
                        new int[,]{ // Stage0
                        {3, 1, 3, 1, 3, 1, 3},
                        {3, 1, 3, 1, 3, 1, 3},
                        {3, 1, 3, 1, 3, 1, 3},
                        },
                        new int[,]{ // Stage1
                        {2, 1, 1, 1, 1, 1},
                        {1, 0, 0, 0, 0, 1},
                        {1, 1, 1, 1, 1, 1},
                        {1, 0, 0, 1, 0, 1},
                        {1, 0, 0, 1, 0, 1},
                        {1, 1, 1, 1, 1, 3},
                        },
                        new int[,]{ // Stage2
                        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                        { 0, 0, 0, 2, 2, 0, 0, 2, 2, 0, 0, 2, 2, 0, 0, 0 },
                        { 1, 1, 1, 3, 3, 1, 1, 3, 3, 1, 1, 3, 3, 1, 1, 1 },
                        { 1, 1, 1, 3, 3, 1, 1, 3, 3, 1, 1, 3, 3, 1, 1, 1 },
                        { 1, 1, 1, 3, 3, 1, 1, 3, 3, 1, 1, 3, 3, 1, 1, 1 },
                        { 1, 1, 1, 3, 3, 1, 1, 3, 3, 1, 1, 3, 3, 1, 1, 1 },
                        { 1, 1, 1, 3, 3, 1, 1, 3, 3, 1, 1, 3, 3, 1, 1, 1 },
                        { 1, 1, 1, 3, 3, 1, 1, 3, 3, 1, 1, 3, 3, 1, 1, 1 },
                        { 0, 0, 0, 2, 2, 0, 0, 2, 2, 0, 0, 2, 2, 0, 0, 0 },
                        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
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