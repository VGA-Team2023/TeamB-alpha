using UnityEngine;
using Glib.InspectorExtension;

namespace TeamB_TD
{
    namespace Battle
    {
        namespace Unit
        {
            namespace Ally
            {
                public class AttackStyleSingleSelecter : MonoBehaviour
                {
                    [SerializeReference, SubclassSelector]
                    private IAllyAttack _select;

                    public IAllyAttack Select => _select;
                }
            }
        }
    }
}