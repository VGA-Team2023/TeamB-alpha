using Cysharp.Threading.Tasks;
using System;
using TeamB_TD.Battle.Unit.Enemy;
using UnityEngine;

namespace TeamB_TD.Battle.Unit.Ally
{
    public class CannonBullet : MonoBehaviour
    {
        [SerializeField]
        private MultiObjectsInTriggerFinder2D _fireArea;

        public async void Fire(EnemyController targetInfo, float duration, float attackPower)
        {
            var startPos = transform.position; // 始点は固定。
            var endPos = targetInfo.transform.position;

            for (var t = 0f; t < duration; t += Time.deltaTime * GameSpeedController.CurretGameSpeed)
            {
                if (targetInfo)
                    endPos = targetInfo.transform.position; // 終点は移動する（可能性がある）。
                transform.position = Vector3.Lerp(startPos, endPos, t / duration);
                try
                {
                    await UniTask.Yield(this.GetCancellationTokenOnDestroy());
                }
                catch (OperationCanceledException)
                {
                    Debug.Log("Canceled...");
                    return;
                }
            }

            var enemies = _fireArea.GetAllObjectsInTrigger<EnemyController>();

            foreach (var enemy in enemies)
            {
                enemy.Damge(attackPower);
            }
            VFXManager.Current.RequestBombVFX(transform.position);
            GameObject.Destroy(gameObject);
        }
    }
}