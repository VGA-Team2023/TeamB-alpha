using UnityEngine;

namespace TeamB_TD
{
    [CreateAssetMenu(fileName = "AllyUnitParameter", menuName = "ScriptableObjects/CreateAllyUnitParameter")]

    public class AllyParameter : ScriptableObject , IWeaponType
    {
        [SerializeField, Header("近距離or遠距離")] private WeaponType _weaponType;
        [SerializeField, Header("ユニットID")] private int _id;
        [SerializeField, Header("HP")] private float _maxLife;
        [SerializeField, Header("攻撃力")] private float _attackPower;
        [SerializeField, Header("最大敵対数")] private int _maxTargetCount;
        [SerializeField, Header("コスト")] private int _cost;
        [SerializeField, Header("攻撃範囲")] private float _attackRange;
        [SerializeField, Header("攻撃インターバル")] private float _attackInterval;

        public WeaponType WeaponType => _weaponType;
        public int ID => _id;
        public float MaxLife => _maxLife;
        public float AttackPower => _attackPower;
        public float MaxTargetCount => _maxTargetCount;
        public float Cost => _cost;
        public float AttackRange => _attackRange;
        public float AttackInterval => _attackInterval;
    }
}
