using System;
using UnityEngine;

namespace TeamB_TD
{
    namespace Battle
    {
        namespace Unit
        {
            public interface IDamageable
            {
                Vector3 WorldPosition { get; }
                void Damage(float value);
                event Action<IDamageable> OnDead;
            }
        }
    }
}