﻿using System.Threading;
using TeamB_TD.Battle.Unit.Ally;
using UnityEngine;

namespace TeamB_TD
{
    namespace Battle
    {
        namespace Craft
        {
            public abstract class CraftableEffect : ScriptableObject
            {
                public abstract CraftType CraftType { get; }

                public abstract CraftableParameter[] Parameters { get; }
                public virtual void RequestEffect(AllyController user, int level, CancellationToken token = default)
                {
                    // Debug.Log(user.gameObject.name);
                }
            }
        }
    }
}