using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "EnemyParameter", menuName = "ScriptableObjects/CreateEnemyParameter", order = 1)]
public class EnemyParamAsset : ScriptableObject
{
    [Header("敵ユニットID")] 
    [SerializeField] int _id;
    [Header("スポーン時の敵の体力")]
    [SerializeField] int _maxlife;
    [Header("敵の移動速度")]
    [SerializeField] int _moveSpeed;
    [Header("敵の攻撃間隔")]
    [SerializeField] float _attackInterval;
    [Header("敵の攻撃周期")]
    [SerializeField] float _attackPeriodicTime; 
    [Header("敵の移動方法")]
    [SerializeField] TeamB_TD.Enemy.MoveCategorize moveCategorize;    
}

