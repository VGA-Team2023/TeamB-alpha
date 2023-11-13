using TeamB_TD.Battle.Unit.Ally;
using UnityEngine;
using UnityEngine.UI;

namespace TeamB_TD
{
    namespace Battle
    {
        namespace Unit
        {
            namespace Enemy
            {
                public class EnemyLifeViewer : MonoBehaviour
                {
                    [SerializeField]
                    private Slider _slider;
                    [SerializeField]
                    private EnemyController _enemyController;

                    public EnemyLifeController LifeController => _enemyController.LifeController;

                    private void Start()
                    {
                        if (_enemyController == null)
                        {
                            Debug.LogWarning("EnemyController is not assigned.");
                        }

                        _slider.minValue = 0f;
                        _slider.maxValue = _enemyController.Param.MaxHP;
                        _slider.value = LifeController.CurrentLife;
                    }

                    private void OnEnable()
                    {
                        LifeController.OnLifeChanged += ApplyValue;
                    }
                    private void OnDisable()
                    {
                        LifeController.OnLifeChanged -= ApplyValue;
                    }

                    private void ApplyValue(float value)
                    {
                        _slider.value = value;
                    }
                }
            }
        }
    }
}