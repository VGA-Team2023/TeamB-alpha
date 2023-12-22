using TeamB_TD.Battle.Unit.Ally;
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
                [SerializeField]
                private AllyController _ally;

                public CraftType CraftType => _craftType;
                public AllyController Ally => _ally;
            }
        }
    }
}