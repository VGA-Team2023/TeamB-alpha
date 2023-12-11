using System.Threading;
using TeamB_TD.Battle.Unit.Ally;
using UnityEngine;

namespace TeamB_TD
{
    namespace Battle
    {
        namespace Craft
        {
            [CreateAssetMenu(fileName = "Makibisi Effect", menuName = "ScriptableObjects/Craftable Effect/Makibisi Effect", order = 0)]
            public class MakibisiEffect : CraftableEffect
            {
                [SerializeField]
                private MakibisiParam[] _makibisiParams;

                public MakibisiParam[] MakibisiParams => _makibisiParams;
                public override CraftableParameter[] Parameters => _makibisiParams;
                public override CraftType CraftType => CraftType.Makibisi;

                public override void RequestEffect(AllyController user, int level, CancellationToken token = default)
                {
                    base.RequestEffect(user, level, token);
                    var index = level - 1;
                    var param = _makibisiParams[index];
                    PlayEffect(user, param);
                }

                private void PlayEffect(AllyController user, MakibisiParam param)
                {
                    GameObject.Instantiate(param.MakibisiPrefab, user.transform.position, Quaternion.identity);
                }
            }
        }
    }
}