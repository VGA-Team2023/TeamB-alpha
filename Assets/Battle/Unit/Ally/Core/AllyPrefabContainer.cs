using UnityEngine;

namespace TeamB_TD
{
    namespace Battle
    {
        namespace Unit
        {
            namespace Ally
            {
                public class AllyPrefabContainer : MonoBehaviour
                {
                    [SerializeField]
                    private AllyController[] _allyPrefabs;

                    public AllyController[] AllyPrefabs => _allyPrefabs;
                }
            }
        }
    }
}