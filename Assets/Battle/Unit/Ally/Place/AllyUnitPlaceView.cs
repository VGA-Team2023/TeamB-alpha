﻿using UnityEngine;
using UnityEngine.UI;

namespace TeamB_TD
{
    namespace Battle
    {
        namespace Unit
        {
            namespace Ally
            {
                public class AllyUnitPlaceView : MonoBehaviour
                {
                    [SerializeField]
                    private Text _costText;
                    [SerializeField]
                    private Image _revivingImage;
                    [SerializeField]
                    private Text _revivingText;
                    [SerializeField]
                    private Image _craftIconImage;
                    [SerializeField]
                    private Image _WeaponTypeImage;
                    [SerializeField]
                    private Sprite _rangeIcon;
                    [SerializeField]
                    private Sprite _meleeIcon;

                    private AllyController _allyPrefab;

                    public AllyController AllyPrefab => _allyPrefab;
                    public Image RevivingImage => _revivingImage;
                    public Text RevivingText => _revivingText;
                    public Image CraftIconImage => _craftIconImage;

                    public void Initialize(AllyController allyPrefab)
                    {
                        _allyPrefab = allyPrefab;
                        _costText.text = $"{allyPrefab.ConstantParams.Cost}";
                        _revivingImage.sprite = allyPrefab.ConstantParams.AllyNonActiveUiSprite;
                        _craftIconImage.sprite = allyPrefab.ConstantParams.AllyCraftIcon;
                        _WeaponTypeImage.sprite = AllyPrefab.ConstantParams.WeaponType switch
                        {
                            WeaponType.None => null,
                            WeaponType.Range => _rangeIcon,
                            WeaponType.Melee => _meleeIcon,
                            _ => null,
                        };
                        ToggleRevivalUiActivate(false);

                        if (TryGetComponent(out Image myImage))
                        {
                            myImage.sprite = _allyPrefab.ConstantParams.AllyActiveUiSprite;
                        }
                    }

                    public void ToggleRevivalUiActivate(bool isActive)
                    {
                        _revivingImage.gameObject.SetActive(isActive);
                        _revivingText.gameObject.SetActive(isActive);
                    }

                    /// <summary>ユニットが再配置出来るまでの間、表示する時間を更新する</summary>
                    /// <param name="revivalCount">ユニット復活までの時間（カウントダウン）</param>
                    public void UpdateRevivingText(float revivalCount)
                    {
                        _revivingText.text =
                            Mathf.Clamp(revivalCount, 0.0f, _allyPrefab.ConstantParams.RevivalInterval).ToString("F2");
                    }
                }
            }
        }
    }
}