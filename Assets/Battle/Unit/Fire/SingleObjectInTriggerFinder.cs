using System;
using System.Collections.Generic;
using UnityEngine;

namespace TeamB_TD
{
    namespace Battle
    {
        namespace Unit
        {
            [Serializable]
            public class SingleObjectInTriggerFinder2D
            {
                [SerializeField]
                private ColliderTriggerHandler2D _colliderTriggerHandler;

                /// <summary> originから最も近いオブジェクトを取得する。 </summary>
                public T GetNearestObject<T>(Vector3 origin) where T : IDamageable
                {
                    T result = default;
                    float minMagnitude = float.MaxValue;

                    var collection = new List<IDamageable>(_colliderTriggerHandler.Damageables);
                    foreach (var item in collection)
                    {
                        if (item is not T) continue;

                        var magnitude = (origin - item.WorldPosition).sqrMagnitude;
                        if (magnitude < minMagnitude)
                        {
                            minMagnitude = magnitude;
                            result = (T)item;
                        }
                    }

                    return result;
                }

                /// <summary> originから最も遠いオブジェクトを取得する。 </summary>
                public T GetFarthestObject<T>(Vector3 origin) where T : IDamageable
                {
                    T result = default;
                    float maxMagnitude = float.MinValue;

                    var collection = new List<IDamageable>(_colliderTriggerHandler.Damageables);
                    foreach (var item in collection)
                    {
                        if (item is not T) continue;

                        var magnitude = (origin - item.WorldPosition).sqrMagnitude;
                        if (magnitude > maxMagnitude)
                        {
                            maxMagnitude = magnitude;
                            result = (T)item;
                        }
                    }

                    return result;
                }

                /// <summary> 最も最初にトリガーの中に侵入したオブジェクトを取得する。 </summary>
                public T GetFirstEnteredObject<T>() where T : IDamageable
                {
                    var collection = new List<IDamageable>(_colliderTriggerHandler.Damageables);

                    foreach (var item in collection)
                    {
                        if (item is T) return (T)item;
                    }

                    return default;
                }

                /// <summary> 最も最後にトリガーの中に侵入したオブジェクトを取得する。 </summary>
                public T GetLastEnteredObject<T>() where T : IDamageable
                {
                    var collection = new List<IDamageable>(_colliderTriggerHandler.Damageables);

                    for (int i = collection.Count - 1; i >= 0; i--)
                    {
                        if (collection[i] is T) return (T)collection[i];
                    }

                    return default;
                }
            }
        }
    }
}