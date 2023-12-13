using UnityEngine;

namespace TeamB_TD
{
    namespace Battle
    {
        namespace Craft
        {
            [CreateAssetMenu(fileName = "Makibisi Param", menuName = "ScriptableObjects/Craftable Parameter/Makibisi Param", order = 0)]
            public class MakibisiParam : CraftableParameter
            {
                [SerializeField]
                private Makibisi _makibisiPrefab;

                public Makibisi MakibisiPrefab => _makibisiPrefab;


                public override string ToString()
                {
                    return $"MakibisiPrefab: {_makibisiPrefab}";
                }
            }
        }
    }
}