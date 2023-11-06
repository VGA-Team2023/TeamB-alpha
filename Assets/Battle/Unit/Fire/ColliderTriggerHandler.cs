// 日本語対応
using System;
using System.Collections.Generic;
using TeamB_TD.Battle;
using UnityEngine;

namespace TeamB_TD
{
    namespace Battle
    {
        namespace Unit
        {
            // 特定のトリガー内に存在するIDamageableをコレクションする。
            // より先に進入してきたIDamageableが先頭に、より後に進入してきたIDamageableが末尾に格納される。
            public class ColliderTriggerHandler : MonoBehaviour
            {
                // ColliderTriggerHandlerを使用する際の注意点。
                // ・RigidBodyを付ける。
                // ・ColliderをTriggerにする。

                private List<IDamageable> _damageables = new List<IDamageable>();

                public IReadOnlyList<IDamageable> Damageables => _damageables;

                public event Action<IDamageable> OnAddeDamageable;
                public event Action<IDamageable> OnRemovedDamageable;

                private void OnTriggerEnter(Collider other)
                {
                    if (other.TryGetComponent(out IDamageable target))
                    {
                        target.OnDead -= RemoveTarget;
                        _damageables.Add(target);
                        target.OnDead += RemoveTarget;
                        OnAddeDamageable?.Invoke(target);
                    }
                }

                private void OnTriggerExit(Collider other)
                {
                    if (other.TryGetComponent(out IDamageable target))
                    {
                        RemoveTarget(target);
                    }
                }

                private void RemoveTarget(IDamageable target)
                {
                    // 正常にコレクションから取り外すことができたらイベントを発行する。
                    if (_damageables.Remove(target))
                        OnRemovedDamageable?.Invoke(target);

                    target.OnDead -= RemoveTarget;

                    //Debug.Log($"{target} Removed:\n" +
                    //    $"Current is {string.Join<ISearchTarget>("\n", _targets)}");
                }
            }
        }
    }
}