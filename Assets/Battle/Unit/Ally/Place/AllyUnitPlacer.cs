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
                    private DragHandler _dragHandler;
                    [SerializeField]
                    private Vector3 _placeOffset;

                    private readonly float _dragItemDistance = 10f;

                    private AllyController _dragItem; // ドラック中のオブジェクト

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

                    private void OnButtonPressed(GameObject mouseOverlappingObject)
                    {
                        if (mouseOverlappingObject &&
                            mouseOverlappingObject.TryGetComponent(out AllyUnitPlaceView placeView))
                        {
                            _dragItem = GameObject.Instantiate(placeView.AllyPrefab);
                        }
                    }

                    private void OnButtonReleased(GameObject mouseOverlappingObject)
                    {
                        if (mouseOverlappingObject &&
                            mouseOverlappingObject.TryGetComponent(out IStageCell stageCell) &&
                            _dragItem)
                        {
                            Place(_dragItem, stageCell);
                        }

                        if (_dragItem)
                        {
                            GameObject.Destroy(_dragItem.gameObject);
                            _dragItem = null;
                        }
                    }

                    private void Place(AllyController allyPrefab, IStageCell stageCell)
                    {
                        // stageCellにallyPrefabを配置する。
                        var position = stageCell.WorldPosition + _placeOffset;
                        Instantiate(allyPrefab, position, Quaternion.identity);
                    }
                }
            }
        }
    }
}