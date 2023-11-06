using UnityEngine;

namespace TeamB_TD
{
    namespace Battle
    {
        namespace StageManagement
        {
            public interface IStageCell
            {
                StageCellStatus Status { get; }
                Vector3 WorldPosition { get; }
            }
        }
    }
}