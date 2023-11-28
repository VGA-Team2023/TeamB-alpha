using System.Collections.Generic;
using UnityEngine;

// 日本語対応
namespace TeamB_TD
{
    namespace Battle
    {
        namespace Unit
        {
            namespace Ally
            {
                public class AllyPlaceableManager : MonoBehaviour
                {
                    public static AllyPlaceableManager Instance { get; private set; } = null;
                    public Dictionary<int, (float Erapse, PlaceableStatus Placeable)> WaitForReviving => _waitForReviving;

                    private AllyPrefabContainer _allyContainer = null;
                    private Dictionary<int, AllyUnitPlaceView> _allyPlaceViewHolder = new Dictionary<int, AllyUnitPlaceView>();

                    /// <summary>ユニットが亡くなった時、再設置可能になるまでの時間を計測する</summary>
                    private Dictionary<int, (float Erapse, PlaceableStatus Placeable)> _waitForReviving
                        = new Dictionary<int, (float, PlaceableStatus)>();
                    /// <summary>復活待ちのユニット</summary>
                    private Queue<int> _waitingQueue = new Queue<int>();

                    private void Awake()
                    {
                        Instance = this;
                    }

                    private void Start()
                    {
                        if (_allyContainer == null) Debug.LogWarning("AllyPrefabContainer is not found");
                        else
                        {
                            foreach (var ally in _allyContainer.AllyPrefabs)
                            {
                                if (_waitForReviving.ContainsKey(ally.ConstantParams.ID)) continue;
                                var allyParam = ally.ConstantParams;
                                _waitForReviving.Add(allyParam.ID, (0.0f, PlaceableStatus.Placeable));
                            }
                        }
                    }

                    public bool IsAllyPlaceable(AllyController ally)
                    {
                        return _waitForReviving[ally.ConstantParams.ID].Placeable == PlaceableStatus.Placeable;
                    }

                    public void PlaceAlly(AllyController ally)
                    {
                        ChangeStatus(ally.ConstantParams.ID, PlaceableStatus.HasPlaced);
                        _allyPlaceViewHolder[ally.ConstantParams.ID].RevivingImage.gameObject.SetActive(true);
                    }

                    public void OnDeadAlly(AllyController ally)
                    {
                        int allyId = ally.ConstantParams.ID;
                        ChangeStatus(allyId, PlaceableStatus.Reviving);
                        _waitingQueue.Enqueue(allyId);
                        ally.OnDeadAlly -= OnDeadAlly;
                    }

                    /// <summary>ユニットが復活するまでの時間を計測する</summary>
                    public void CalcRevivingTime()
                    {
                        if (_waitingQueue.Count == 0) return;

                        for (int i = 0, loopCount = _waitingQueue.Count; i < loopCount; i++)
                        {
                            int n = _waitingQueue.Dequeue();
                            _waitForReviving[n] =
                                (_waitForReviving[n].Erapse + Time.deltaTime * GameSpeedController.CurretGameSpeed,
                                PlaceableStatus.Reviving);
                            float allyRevivalInterval = _allyPlaceViewHolder[n].AllyPrefab.ConstantParams.RevivalInterval;
                            _allyPlaceViewHolder[n].RevivingText.gameObject.SetActive(true);
                            _allyPlaceViewHolder[n].UpdateRevivingText(allyRevivalInterval - _waitForReviving[n].Erapse);

                            if (_waitForReviving[n].Erapse < allyRevivalInterval) { _waitingQueue.Enqueue(n); continue; }

                            ChangeStatus(n, PlaceableStatus.Placeable);
                            _allyPlaceViewHolder[n].ToggleRevivalUiActivate(false);
                        }
                    }

                    /// <summary>ユニットの現在の状態を更新する</summary>
                    /// <param name="allyId">状態を更新するユニットのID</param>
                    /// <param name="status">どの状態に更新するか</param>
                    public void ChangeStatus(int allyId, PlaceableStatus status)
                    {
                        _waitForReviving[allyId] = (0.0f, status);
                    }

                    public void SetAllyContainer(AllyPrefabContainer container) => _allyContainer = container;

                    public void AddPlaceViewHolder(int allyId, AllyUnitPlaceView allyView)
                    {
                        if (_allyPlaceViewHolder.ContainsKey(allyId)) return;

                        _allyPlaceViewHolder.Add(allyId, allyView);
                    }
                }
            }
        }
    }
}
