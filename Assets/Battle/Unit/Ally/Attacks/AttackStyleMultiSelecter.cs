using Glib.InspectorExtension;
using UnityEngine;

namespace TeamB_TD
{
    namespace Battle
    {
        namespace Unit
        {
            namespace Ally
            {
                public class AttackStyleMultiSelecter : MonoBehaviour
                {
                    [SerializeReference, SubclassSelector]
                    private IAllyAttack[] _allyAttacks;

                    public IAllyAttack[] AllyAttacks => _allyAttacks;
                }
            }
        }
    }
}