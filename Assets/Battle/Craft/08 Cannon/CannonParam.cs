using UnityEngine;

namespace TeamB_TD
{
    namespace Battle
    {
        namespace Craft
        {
            [CreateAssetMenu(fileName = "Portion Param", menuName = "ScriptableObjects/Craftable Parameter/Cannon Param", order = 0)]
            public class CannonParam : CraftableParameter
            {
                [SerializeField]
                private float _effectDuration = 20f;
                [SerializeField]
                private float _powerupAmount = 30f; // 攻撃力上昇量(単位: ％)

                public float EffectorDuration => _effectDuration;
                public float PowerupAmount => _powerupAmount;

                public override string ToString()
                {
                    return $"EffectDuration: {_effectDuration}";
                }
            }
        }
    }
}