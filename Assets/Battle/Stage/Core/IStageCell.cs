using UnityEngine;

namespace TeamB_TD
{
    namespace Battle
    {
        namespace StageManagement
        {
            public interface IStageCell
            {
                GameObject GameObject { get; }
                StageCellStatus Status { get; }
                Vector3 WorldPosition { get; }

                int XPos { get; }
                int YPos { get; }

                public IStageCell Parent { get; set; }
            }
        }
    }
}