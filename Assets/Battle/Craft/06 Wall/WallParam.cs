using UnityEngine;

namespace TeamB_TD
{
    namespace Battle
    {
        namespace Craft
        {
            [CreateAssetMenu(fileName = "Wall Param", menuName = "ScriptableObjects/Craftable Parameter/Wall Param", order = 0)]
            public class WallParam : CraftableParameter
            {
                [SerializeField]
                private WallController _wallUnitPrefab;
                [SerializeField]
                private float _wallLife = 300f;

                public WallController WallUnitPrefab => _wallUnitPrefab;
                public float WallLife => _wallLife;

                public override string ToString()
                {
                    return $"WallUnitPrefab: {_wallUnitPrefab}";
                }
            }
        }
    }
}