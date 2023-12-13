using UnityEngine;
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
                    private Text _nameText;
                    [SerializeField]
                    private Text _costText;
                    [SerializeField]
                    private Image _revivingImage;
                    [SerializeField]
                    private Text _revivingText;

                    private AllyController _allyPrefab;

                    public AllyController AllyPrefab => _allyPrefab;
                    public Image RevivingImage => _revivingImage;
                    public Text RevivingText => _revivingText;

                    public void Initialize(AllyController allyPrefab)
                    {
                        _allyPrefab = allyPrefab;
                        _costText.text = $"{allyPrefab.ConstantParams.Cost}";
                        _revivingImage.sprite = allyPrefab.ConstantParams.AllyNonActiveUiSprite;
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