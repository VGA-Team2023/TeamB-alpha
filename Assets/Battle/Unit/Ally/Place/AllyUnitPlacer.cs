using System;
using TeamB_TD.Battle.ResourceManagement;
using TeamB_TD.Battle.StageManagement;
using TeamB_TD.Utility;
using UnityEngine;

namespace TeamB_TD
{
    namespace Battle
    {
        namespace Unit
        {
            namespace Ally
            {
                public class AllyUnitPlacer : MonoBehaviour
                {
                    [SerializeField]
                    private ResourceManager _resourceManager;
                    [SerializeField]
                    private DragHandler _dragHandler;
                    [SerializeField]
                    private Vector3 _placeOffset;

                    private readonly float _dragItemDistance = 10f;

                    private AllyController _dragItem; // ドラック中のオブジェクト

                    private void Start()
                    {
                        if (_resourceManager == null)
                        {
                            Debug.LogWarning("ResourceManager is not assigned");
                        }
                    }

                    private void OnEnable()
                    {
                        if (_dragHandler)
                        {
                            _dragHandler.OnButtonPressed += OnButtonPressed;
                            _dragHandler.OnButtonReleased += OnButtonReleased;
                        }
                    }

                    private void OnDisable()
                    {
                        if (_dragHandler)
                        {
                            _dragHandler.OnButtonPressed -= OnButtonPressed;
                            _dragHandler.OnButtonReleased -= OnButtonReleased;
                        }
                    }

                    private void Update()
                    {
                        if (_dragItem)
                        {
                            Vector3 mouseWorldPos = GetMouseWorldPosition();
                            _dragItem.transform.position = mouseWorldPos;
                            _dragItem.Renderer.sortingOrder = (int)(-mouseWorldPos.y * 5f + 100f);
                        }
                        AllyPlaceableManager.Instance.CalcRevivingTime();
                    }

                    private void OnButtonPressed(GameObject mouseOverlappingObject) // ドラッグ開始（マウス左ボタン押下時）
                    {
                        if (mouseOverlappingObject &&
                            mouseOverlappingObject.TryGetComponent(out AllyUnitPlaceView placeView) &&
                            AllyPlaceableManager.Instance.IsAllyPlaceable(placeView.AllyPrefab))
                        {
                            _dragItem = GameObject.Instantiate(placeView.AllyPrefab);
                            _dragItem.enabled = false;
                            _dragItem.GetComponent<Collider2D>().enabled = false;

                            Vector3 mouseWorldPos = GetMouseWorldPosition();
                            _dragItem.transform.position = mouseWorldPos;
                        }
                    }

                    private void OnButtonReleased(GameObject mouseOverlappingObject) // ドラッグ終了（マウス左ボタン解放時）
                    {
                        if (TryGetCell(mouseOverlappingObject, out IStageCell cell) &&
                            IsPlacable(_dragItem, cell, _resourceManager) &&
                            AllyPlaceableManager.Instance.IsAllyPlaceable(_dragItem))
                        {
                            Place(_dragItem, cell);
                        }

                        if (_dragItem != null)
                        {
                            Destroy(_dragItem.gameObject);
                            _dragItem = null;
                        }
                    }

                    public event Action<AllyController> OnPlacedAlly;

                    private void Place(AllyController allyPrefab, IStageCell stageCell)
                    {
                        // stageCellにallyPrefabを配置する。
                        allyPrefab.enabled = true;
                        allyPrefab.GetComponent<Collider2D>().enabled = true;
                        var position = stageCell.WorldPosition + _placeOffset;
                        var instance = Instantiate(allyPrefab, position, Quaternion.identity);
                        var cell = stageCell as StageCell;
                        AllyPlaceableManager.Instance.PlaceAlly(instance);
                        instance.Renderer.sortingOrder = _dragItem.Renderer.sortingOrder;
                        instance.OnDeadAlly += AllyPlaceableManager.Instance.OnDeadAlly;
                        _resourceManager.TryUseResource(allyPrefab.ConstantParams.Cost);
                        OnPlacedAlly?.Invoke(instance);
                    }

                    private bool TryGetCell(GameObject gameObject, out IStageCell cell)
                    {
                        cell = null;
                        if (gameObject == null) return false;
                        return gameObject.TryGetComponent(out cell);
                    }

                    private bool IsPlacable(AllyController prefab, IStageCell cell, ResourceManager resource)
                    {
                        if (!prefab) return false;
                        if (!cell.Status.HasFlag(StageCellStatus.UnitPlacable)) return false;
                        if (_resourceManager.CurrentResource - _dragItem.ConstantParams.Cost < 0) return false;

                        return true;
                    }

                    private Vector3 GetMouseWorldPosition()
                    {
                        var mousePos = Input.mousePosition;
                        mousePos.z = _dragItemDistance;
                        return Camera.main.ScreenToWorldPoint(mousePos);
                    }
                }
            }
        }
    }
}