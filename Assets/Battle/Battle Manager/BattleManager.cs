using System;
using System.Net;
using TeamB_TD.Battle.Tower;
using TeamB_TD.Battle.Unit.Enemy;
using UnityEngine;

namespace TeamB_TD
{
    namespace Battle
    {
        [DefaultExecutionOrder(-90)]
        public class BattleManager : MonoBehaviour
        {
            private static BattleManager _current;
            public static BattleManager Current => _current;

            [SerializeField] private Result.GameResultController _result = null;

            private BattleStatus _status = BattleStatus.Ready;

            public BattleStatus Status
            {
                get => _status;
                private set
                {
                    var old = _status;
                    _status = value;
                    if (old != _status) { OnStatusChanged?.Invoke(_status); }
                }
            }

            public event Action<BattleStatus> OnStatusChanged;

            private void Awake()
            {
                _current = this;
            }

            private void Start()
            {
                CriAudioManager.Instance.BGM.Play("BGM", "BGM_001_battle", 0.8f);
            }

            //TODO:α用の突貫工事リザルト表示なのでリファクタする。
            private bool _isGameFinish = false;

            private void Update()
            {
                if (EnemyCounter.Current.CompletedEnemyCount >= EnemyCounter.Current.TotalEnemyCount && !_isGameFinish)
                {
                    StartCoroutine(_result.GameClearResultSet());
                    GameClear();
                    _isGameFinish = true;
                }

                else if(TowerController.Instance.Life <= 0)
                {
                    _result.GameOverResultSet();
                    _isGameFinish = true;
                }
            }

            private void GameClear()
            {
                Status = BattleStatus.GameClear;
            }

            private void GameOver()
            {
                Status = BattleStatus.GameOver;
            }

            public enum BattleStatus
            {
                Ready,
                Playing,
                GameOver,
                GameClear,
            }
        }
    }
}