using UnityEngine;

namespace TeamB_TD
{
    namespace Battle
    {
        namespace Craft
        {
            [CreateAssetMenu(fileName = "Portion Param", menuName = "ScriptableObjects/Craftable Parameter/Portion Param", order = 0)]
            public class PortionParam : CraftableParameter
            {
                [SerializeField]
                private float _healAmount = 30f; // 回復量(単位: ％)

                public float HealAmount => _healAmount;

                public override string ToString()
                {
                    return $"HealAmount: {_healAmount}";
                }
            }
        }
    }
}