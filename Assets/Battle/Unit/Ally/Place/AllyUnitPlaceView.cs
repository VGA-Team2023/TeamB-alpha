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

                    public void Initialize(AllyController allyPrefab)
                    {
                        _allyPrefab = allyPrefab;
                        _costText.text = $"{allyPrefab.ConstantParams.Cost}";
                        ToggleRevivalUiActivate(false);
                    }

                    private bool _isActive = true;

                    public void ToggleRevivalUiActivate(bool isActive)
                    {
                        if (_isActive == isActive) return;

                        _revivingImage.gameObject.SetActive(isActive);
                        _revivingText.gameObject.SetActive(isActive);
                        _isActive = isActive;
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