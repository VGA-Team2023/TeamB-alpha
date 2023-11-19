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
            [CreateAssetMenu(fileName = "Horn Effect", menuName = "ScriptableObjects/Craftable Effect/Horn Effect", order = 0)]
            public class HornEffect : CraftableEffect
            {
                [SerializeField]
                private HornParam[] _hornParams;

                public HornParam[] HornParams => _hornParams;
                public override CraftableParameter[] Parameters => _hornParams;

                public override CraftType CraftType => CraftType.Horn;

                public override void RequestEffect(AllyType user, int level, CancellationToken token = default)
                {
                    var index = level - 1;
                    var param = _hornParams[index];
                    PlayEffect(param);
                }

                private void PlayEffect(HornParam param)
                {
                    Debug.Log(param.ToString());
                }
            }
        }
    }
}