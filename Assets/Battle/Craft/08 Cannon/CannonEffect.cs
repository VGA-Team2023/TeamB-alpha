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
            [CreateAssetMenu(fileName = "Cannon Effect", menuName = "ScriptableObjects/Craftable Effect/Cannon Effect", order = 0)]
            public class CannonEffect : CraftableEffect
            {
                [SerializeField]
                private CannonParam[] _cannonParams;

                public CannonParam[] CannonParams => _cannonParams;
                public override CraftableParameter[] Parameters => _cannonParams;

                public override CraftType CraftType => CraftType.Cannon;

                public override void RequestEffect(AllyType user, int level, CancellationToken token = default)
                {
                    var index = level - 1;
                    var param = _cannonParams[index];
                    PlayEffect(param);
                }

                private void PlayEffect(CannonParam param)
                {
                    Debug.Log(param.ToString());
                }
            }
        }
    }
}