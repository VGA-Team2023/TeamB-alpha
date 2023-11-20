using UnityEngine;

namespace TeamB_TD
{
    namespace Battle
    {
        namespace Craft
        {
            public abstract class CraftableParameter : ScriptableObject
            {
                [SerializeField]
                private string _name;

                public string Name => _name;
            }
        }
    }
}