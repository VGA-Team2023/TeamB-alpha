﻿using Cysharp.Threading.Tasks;
using System;
using TeamB_TD.Battle.Unit.Enemy;
using UnityEngine;

namespace TeamB_TD.Battle.Unit.Ally
{
    public class BombController : MonoBehaviour
    {
        public async void Throw(EnemyController targetInfo, float duration, float attackPower)
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

            if (targetInfo) targetInfo.Damage(attackPower);
            VFXManager.Current.RequestBombVFX(transform.position);
            GameObject.Destroy(gameObject);
        }
    }
}