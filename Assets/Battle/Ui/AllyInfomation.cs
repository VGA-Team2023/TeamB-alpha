using System.Collections;
using System.Collections.Generic;
using TeamB_TD.Battle.Unit.Ally;
using TeamB_TD.Utility;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// 日本語対応
namespace TeamB_TD
{
    namespace Battle
    {
        namespace Unit
        {
            public class AllyInfomation : MonoBehaviour, IPointerClickHandler
            {
                [SerializeField, Header("ドラッグハンドラー")]
                private DragHandler _dragHandler = null;
                [SerializeField, Header("ユニットのステータスを表示するイメージ")]
                private Image _allyStandingImage = null;
                [SerializeField, Header("パラメータ表示時のゲームスピード")]
                private float _isPausedGameSpeed = 1f / 3f;

                private bool _isShowInfo = false;
                private Image _myPanel = null;
                private Color _defaultColor = Color.white;
                /// <summary>前回のゲームスピードを記録する</summary>
                private float _saveGameSpeed = 0f;
                private List<GameObject> _childrenList = new List<GameObject>();

                private void OnEnable()
                {
                    if (_dragHandler)
                    {
                        _dragHandler.OnButtonReleased += UpdateAllyInfomation;
                    }
                }

                private void Start()
                {
                    if (TryGetComponent(out Image image)) { _myPanel = image; }

                    for(int i = 0; i < transform.childCount; i++)
                    {
                        _childrenList.Add(transform.GetChild(i).gameObject);
                    }
                    _saveGameSpeed = GameSpeedController.CurrentSpeed;
                    _allyStandingImage.color = Color.white;
                    StartCoroutine(ChangeActivateAsync());
                }

                private void OnDisable()
                {
                    if (_dragHandler)
                    {
                        _dragHandler.OnButtonReleased -= UpdateAllyInfomation;
                    }
                }

                public void OnPointerClick(PointerEventData eventData)
                {
                    _isShowInfo = false;
                }

                private void UpdateAllyInfomation(GameObject allyGo)
                {
                    if (allyGo == null) { return; }
                    if (!allyGo.TryGetComponent(out AllyUnitPlaceView allyView)) { return; }

                    _isShowInfo = true;

                    var ally = allyView.AllyPrefab;
                    _allyStandingImage.sprite = ally.ConstantParams.AllyStatusSprite ?? null;
                }

                private IEnumerator ChangeActivateAsync()
                {
                    bool isActive = !_isShowInfo;

                    while (true)
                    {
                        yield return new WaitUntil(() => isActive != _isShowInfo);
                        isActive = _isShowInfo;
                        SwitchActivate(isActive);
                    }
                }

                /// <summary>ユニットの情報を表示するPanelのアクティブ・非アクティブを切り替える</summary>
                /// <param name="isActive">アクティブにするかどうか</param>
                private void SwitchActivate(bool isActive)
                {
                    _myPanel.raycastTarget = isActive;

                    if (isActive)  // アクティブ時
                    {
                        _myPanel.color = _defaultColor;
                        _saveGameSpeed = GameSpeedController.CurrentSpeed;
                        GameSpeedController.ChangeGameSpeed(_isPausedGameSpeed);
                    }
                    else  // 非アクティブ時
                    {
                        _defaultColor = _myPanel.color;
                        _myPanel.color = Color.clear;
                        GameSpeedController.ChangeGameSpeed(_saveGameSpeed);
                    }

                    foreach (var item in _childrenList)
                    {
                        item.SetActive(isActive);
                    }
                }
            }
        }
    }
}