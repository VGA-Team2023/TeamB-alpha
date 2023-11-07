using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "EnemyParameter", menuName = "ScriptableObjects/CreateEnemyParameter", order = 1)]
public class EnemyParamAsset : ScriptableObject
{
    [Header("敵ユニットID")] 
    [SerializeField] private int _id;
    [Header("スポーン時の敵の体力")]
    [SerializeField] private int _maxLife;
    [Header("敵の移動速度")]
    [SerializeField] private float _moveSpeed;
    [Header("敵の攻撃間隔")]
    [SerializeField] private float _attackInterval;
    [Header("敵の攻撃周期")]
    [SerializeField] private float _attackPeriodicTime; 
    [Header("敵の移動方法")]
    [SerializeField] private TeamB_TD.Enemy.MoveCategorize moveCategorize;

    public int ID => _id;
    public int MaxHP => _maxLife;
    public float MoveSpeed => _moveSpeed;
    public float AttackInterval => _attackInterval;
    public float AttackPeriodicTime => _attackPeriodicTime;
}

