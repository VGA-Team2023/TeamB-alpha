using System;
using System.Threading;
using TeamB_TD.Battle.Unit.Ally;
using UnityEngine;

namespace TeamB_TD
{
    namespace Battle
    {
        namespace Craft
        {
            [CreateAssetMenu(fileName = "Wall Effect", menuName = "ScriptableObjects/Craftable Effect/Wall Effect", order = 0)]
            public class WallEffect : CraftableEffect
            {
                [SerializeField]
                private WallParam[] _wallParams;

                public WallParam[] WallParams => _wallParams;
                public override CraftableParameter[] Parameters => _wallParams;

                public override CraftType CraftType => CraftType.Wall;

                public override void RequestEffect(AllyController user, int level, CancellationToken token = default)
                {
                    base.RequestEffect(user, level, token);
                    var index = level - 1;
                    var param = _wallParams[index];
                    PlayEffect(param);
                }

                private void PlayEffect(WallParam param)
                {
                    Debug.Log(param.ToString());
                }
            }
        }
    }
}