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
            [CreateAssetMenu(fileName = "Portion Effect", menuName = "ScriptableObjects/Craftable Effect/Portion Effect", order = 0)]
            public class PortionEffect : CraftableEffect
            {
                [SerializeField]
                private PortionParam[] _portionParams;

                public PortionParam[] PortionParams => _portionParams;
                public override CraftableParameter[] Parameters => _portionParams;

                public override CraftType CraftType => CraftType.Portion;

                public override void RequestEffect(AllyType user, int level, CancellationToken token = default)
                {
                    var index = level - 1;
                    var param = _portionParams[index];
                    PlayEffect(param);
                }

                private void PlayEffect(PortionParam param)
                {
                    Debug.Log(param.ToString());
                }
            }
        }
    }
}