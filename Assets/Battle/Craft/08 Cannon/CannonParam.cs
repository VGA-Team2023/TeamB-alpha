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

                public float EffectorDuration => _effectDuration;

                public override string ToString()
                {
                    return $"EffectDuration: {_effectDuration}";
                }
            }
        }
    }
}