using UnityEngine;

namespace TeamB_TD
{
    namespace Battle
    {
        namespace Craft
        {
            [CreateAssetMenu(fileName = "Bomb Param", menuName = "ScriptableObjects/Craftable Parameter/Bomb Param", order = 0)]
            public class BombParam : CraftableParameter
            {
                [SerializeField]
                private float _startDuration = 1f;
                [SerializeField]
                private float _effectDuration = 20f;
                [SerializeField]
                private float _powerupAmount = 30f; // 攻撃力上昇量(単位: ％)

                public float StartDuration => _startDuration;
                public float EffectDuration => _effectDuration;
                public float PowerupAmount => _powerupAmount;

                public override string ToString()
                {
                    return $"EffectDuration: {_effectDuration}";
                }
            }
        }
    }
}