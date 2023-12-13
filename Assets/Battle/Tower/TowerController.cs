using System;
using System.Collections;
using System.Collections.Generic;
using TeamB_TD.Battle.Unit.Enemy;
using UnityEngine;


namespace TeamB_TD
{
    namespace Battle
    {
        namespace Tower
        {
            public class TowerController : MonoBehaviour
            {
                [Header("タワーの体力の最大値")]
                [SerializeField]
                private int _maxLife = 20;

                private static TowerController _instance = null;
                private int _currentLife = 0;

                public static TowerController Instance => _instance;
                public int Life => _currentLife;

                public Action<int> OnLifeChanged; //ライフ変化時に発火するイベント
                public Action OnDead; //死亡時に発火するイベント

                private void Awake()
                {
                    _instance = this;
                }

                void Start()
                {
                    _currentLife = _maxLife;

                    EnemyCounter.Current.OnTowerInvasionCountChanged += _ => Damage();
                }

                public void Damage()
                {
                    if (_currentLife <= 0) return;
                    _currentLife--;
                    OnLifeChanged?.Invoke(_currentLife);
                    if (_currentLife == 0)
                        OnDead?.Invoke();
                }
            }
        }
    }
}