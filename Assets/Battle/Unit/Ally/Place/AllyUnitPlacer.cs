﻿using TeamB_TD.Battle.ResourceManagement;
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
                            var mousePos = Input.mousePosition;
                            mousePos.z = _dragItemDistance;
                            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

                            _dragItem.transform.position = worldPos;
                        }
                    }

                    private void OnButtonPressed(GameObject mouseOverlappingObject) // ドラッグ開始（マウス左ボタン押下時）
                    {
                        if (mouseOverlappingObject &&
                            mouseOverlappingObject.TryGetComponent(out AllyUnitPlaceView placeView))
                        {
                            _dragItem = GameObject.Instantiate(placeView.AllyPrefab);
                            _dragItem.enabled = false;
                            _dragItem.GetComponent<Collider2D>().enabled = false;
                        }
                    }

                    private void OnButtonReleased(GameObject mouseOverlappingObject) // ドラッグ終了（マウス左ボタン解放時）
                    {
                        if (TryGetCell(mouseOverlappingObject, out IStageCell cell) &&
                            IsPlacable(_dragItem, cell, _resourceManager))
                        {
                            Place(_dragItem, cell);
                        }

                        if (_dragItem != null)
                        {
                            GameObject.Destroy(_dragItem.gameObject);
                            _dragItem = null;
                        }
                    }

                    private void Place(AllyController allyPrefab, IStageCell stageCell)
                    {
                        // stageCellにallyPrefabを配置する。
                        allyPrefab.enabled = true;
                        allyPrefab.GetComponent<Collider2D>().enabled = true;
                        var position = stageCell.WorldPosition + _placeOffset;
                        Instantiate(allyPrefab, position, Quaternion.identity);
                        _resourceManager.TryUseResource(allyPrefab.Cost);
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
                        if (_resourceManager.CurrentResource - _dragItem.Cost < 0) return false;

                        return true;
                    }
                }
            }
        }
    }
}