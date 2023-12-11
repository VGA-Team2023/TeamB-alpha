using System.Collections.Generic;
using TeamB_TD.Battle.Unit;
using TeamB_TD.Battle.Unit.Enemy;
using UnityEngine;

namespace TeamB_TD.Battle.Craft
{
    public class Makibisi : MonoBehaviour
    {
        // 周囲の敵に定期的にダメージを与える。
        // 周囲の敵の移動速度を下げる。
        [SerializeField]
        private MultiObjectsInTriggerFinder2D _targetGetter;

        [SerializeField, Range(3f, 30f)]
        private float _duration = 10f;
        [SerializeField, Range(0.01f, 1f)]
        private float _decelerationRate = 0.9f;
        [SerializeField, Range(0.1f, 3f)]
        private float _fireInterval = 1f;
        [SerializeField, Range(1f, 50f)]
        private float _attackPower = 10f;

        private List<EnemyController> _old = new List<EnemyController>();
        public IReadOnlyList<EnemyController> TargetEnemies => _targetGetter.GetAllObjectsInTrigger<EnemyController>();

        private float _durationTimer = 0f;
        private float _fireIntervalTimer = 0f;

        private void Update()
        {
            foreach (var oldEnemy in _old)
            {
                if (oldEnemy != null) oldEnemy.ChangeMoveSpeedDecelerationRate(1f);
            }
            _old.Clear();

            var targets = TargetEnemies;

            _fireIntervalTimer += Time.deltaTime * GameSpeedController.CurretGameSpeed;
            _durationTimer += Time.deltaTime * GameSpeedController.CurretGameSpeed;
            if (_fireIntervalTimer > _fireInterval)
            {
                _fireIntervalTimer -= _fireInterval;
                foreach (var enemy in targets)
                {
                    enemy.Damge(_attackPower);
                }
            }

            foreach (var enemy in targets)
            {
                enemy.ChangeMoveSpeedDecelerationRate(_decelerationRate);
            }
            _old.AddRange(targets);

            if (_durationTimer > _duration)
            {
                Destroy(gameObject);
            }
        }

        private void OnDestroy()
        {
            foreach (var oldEnemy in _old)
            {
                if (oldEnemy != null) oldEnemy.ChangeMoveSpeedDecelerationRate(1f);
            }
        }
    }
}