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
            public class MultiObjectsInTriggerFinder2D
            {
                [SerializeField]
                private ColliderTriggerHandler2D _colliderTriggerHandler;

                /// <summary> トリガー内に存在する全てのコライダー付きのT型を取得する。 </summary>
                public List<T> GetAllObjectsInTrigger<T>() where T : IDamageable
                {
                    List<T> result = new List<T>();
                    List<IDamageable> collection = new List<IDamageable>(_colliderTriggerHandler.Damageables);

                    foreach (var item in collection)
                    {
                        if (item is T)
                        {
                            result.Add((T)item);
                        }
                    }

                    return result;
                }

                /// <summary> より近いオブジェクトを数を指定して取得します。 </summary>
                public List<T> FindNearestObjects<T>(Vector3 origin, int count) where T : IDamageable
                {
                    List<T> result = new List<T>();
                    List<IDamageable> collection = new List<IDamageable>(_colliderTriggerHandler.Damageables);

                    // 距離でソートされたオブジェクトリストを作成
                    collection.Sort((a, b) =>
                    {
                        float distanceA = Vector3.Distance(a.WorldPosition, origin);
                        float distanceB = Vector3.Distance(b.WorldPosition, origin);
                        return distanceA.CompareTo(distanceB);
                    });

                    foreach (var item in collection)
                    {
                        if (item is T)
                        {
                            result.Add((T)item);
                            if (result.Count == count)
                            {
                                break; // 指定数のオブジェクトを取得したらループを終了
                            }
                        }
                    }

                    return result;
                }

                /// <summary> より遠いオブジェクトを数を指定して取得します。 </summary>
                public List<T> FindFarthestObjects<T>(Vector3 origin, int count) where T : IDamageable
                {
                    List<T> result = new List<T>();
                    List<IDamageable> collection = new List<IDamageable>(_colliderTriggerHandler.Damageables);

                    // 距離でソートされたオブジェクトリストを作成
                    collection.Sort((a, b) =>
                    {
                        float distanceA = Vector3.Distance(a.WorldPosition, origin);
                        float distanceB = Vector3.Distance(b.WorldPosition, origin);
                        return distanceB.CompareTo(distanceA); // 逆順にソート
                    });

                    foreach (var item in collection)
                    {
                        if (item is T)
                        {
                            result.Add((T)item);
                            if (result.Count == count)
                            {
                                break; // 指定数のオブジェクトを取得したらループを終了
                            }
                        }
                    }

                    return result;
                }

                /// <summary> より先にトリガーに侵入したオブジェクトから数を指定して取得します。 </summary>
                public List<T> FindFirstIntruders<T>(int count) where T : IDamageable
                {
                    List<T> result = new List<T>();
                    List<IDamageable> collection = new List<IDamageable>(_colliderTriggerHandler.Damageables);

                    foreach (var item in collection)
                    {
                        if (item is not T) continue;

                        result.Add((T)item);
                        if (result.Count == count) return result;
                    }

                    return result;
                }

                /// <summary> より後にトリガーに侵入したオブジェクトから数を指定して取得します。 </summary>
                public List<T> FindLastIntruders<T>(int count) where T : IDamageable
                {
                    List<T> result = new List<T>();
                    List<IDamageable> collection = new List<IDamageable>(_colliderTriggerHandler.Damageables);

                    for (int i = collection.Count - 1; i >= 0; i--)
                    {
                        if (collection[i] is not T) continue;

                        result.Add((T)collection[i]);
                        if (result.Count == count) return result;
                    }

                    return result;
                }
            }
        }
    }
}