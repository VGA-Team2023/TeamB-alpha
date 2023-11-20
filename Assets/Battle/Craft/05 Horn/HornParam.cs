using UnityEngine;

namespace TeamB_TD
{
    namespace Battle
    {
        namespace Craft
        {
            [CreateAssetMenu(fileName = "Horn Param", menuName = "ScriptableObjects/Craftable Parameter/Horn Param", order = 0)]
            public class HornParam : CraftableParameter
            {
                [SerializeField]
                private GameObject _smallAllyPrefab;

                public GameObject SmallAllyPrefab => _smallAllyPrefab;


                public override string ToString()
                {
                    return $"SmallAllyPrefab: {_smallAllyPrefab}";
                }
            }
        }
    }
}