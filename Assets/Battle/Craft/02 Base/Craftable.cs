using UnityEngine;

namespace TeamB_TD
{
    namespace Battle
    {
        namespace Craft
        {
            public class Craftable : MonoBehaviour
            {
                [SerializeField]
                private CraftType _craftType;

                public CraftType CraftType => _craftType;
            }
        }
    }
}