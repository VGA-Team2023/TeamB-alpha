using UnityEngine;

namespace TeamB_TD
{
    namespace Battle
    {
        namespace StageManagement
        {
            public interface IStage
            {
                IStageCell[,] StageData { get; }
            }
        }
    }
}