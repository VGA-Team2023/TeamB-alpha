using System;
using System.Collections.Generic;
using TeamB_TD.Battle.Unit.Ally;
using UnityEngine;

namespace TeamB_TD
{
    namespace Battle
    {
        namespace Craft
        {
            public class CraftManager : MonoBehaviour
            {
                private static CraftManager _current;
                public static CraftManager Current => _current;

                [SerializeField]
                private FlagEffect _flagEffect;
                [SerializeField]
                private BombEffect _bombEffect;
                [SerializeField]
                private HornEffect _hornEffect;
                [SerializeField]
                private WallEffect _wallEffect;
                [SerializeField]
                private PortionEffect _portionEffect;
                [SerializeField]
                private CannonEffect _cannonEffect;

                private Dictionary<CraftType, CraftableEffect> _effects = new Dictionary<CraftType, CraftableEffect>();

                public IReadOnlyDictionary<CraftType, CraftableEffect> Effects => _effects;

                private void Awake()
                {
                    _current = this;

                    _effects.Add(CraftType.Flag, _flagEffect);
                    _effects.Add(CraftType.Bomb, _bombEffect);
                    _effects.Add(CraftType.Horn, _hornEffect);
                    _effects.Add(CraftType.Wall, _wallEffect);
                    _effects.Add(CraftType.Portion, _portionEffect);
                    _effects.Add(CraftType.Cannon, _cannonEffect);
                }
            }
        }
    }
}