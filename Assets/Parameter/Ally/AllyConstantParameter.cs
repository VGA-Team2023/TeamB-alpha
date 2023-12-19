using UnityEngine;
using System;

namespace TeamB_TD
{
    [CreateAssetMenu(fileName = "AllyUnitParameter", menuName = "ScriptableObjects/CreateAllyUnitParameter")]

    public class AllyConstantParameter : ScriptableObject, IWeaponType
    {
        [SerializeField, Header("近距離or遠距離")] private WeaponType _weaponType;
        [SerializeField, Header("ユニットID")] private int _id;
        [SerializeField, Header("HP")] private float _maxLife;
        [SerializeField, Header("攻撃力")] private float _attackPower;
        [SerializeField, Header("最大敵対数")] private int _maxTargetCount;
        [SerializeField, Header("コスト")] private int _cost;
        [SerializeField, Header("攻撃範囲")] private float _attackRange;
        [SerializeField, Header("攻撃インターバル")] private float _attackInterval;
        [SerializeField, Header("再配置可能インターバル")] private float _revivalInterval;

        public WeaponType WeaponType => _weaponType;
        public int ID => _id;
        public float MaxLife => _maxLife;
        public float AttackPower => _attackPower;
        public int MaxTargetCount => _maxTargetCount;
        public float Cost => _cost;
        public float AttackRange => _attackRange;
        public float AttackInterval => _attackInterval;
        public float RevivalInterval => _revivalInterval;
        public Sprite AllyActiveUiSprite => _allyActiveUiSprite;
        public Sprite AllyNonActiveUiSprite => _allyNonActiveUiSprite;
        public Sprite AllyStandingSprite => _allyStandingSprite;
        public Sprite AllyCraftIcon => _allyCraftIcon;

        [Header("====================")]
        [SerializeField]
        private GameObject _allyPrefab; // 対応する味方ユニットのプレハブ。
        [SerializeField]
        private Sprite _allyActiveUiSprite; // 対応する味方ユニットが配置可能時に表示するUI
        [SerializeField]
        private Sprite _allyNonActiveUiSprite; // 対応する味方ユニットが配置不可能時に表示するUI
        [SerializeField]
        private Sprite _allyStandingSprite; // 対応する味方ユニットの立ち絵
        [SerializeField]
        private Sprite _allyCraftIcon; // 対応する味方ユニットのクラフトアイコン

        private void OnValidate()
        {
            if (_allyPrefab == null) return;
            var trigger = _allyPrefab.GetComponentInChildren<Battle.Unit.ColliderTriggerHandler2D>();
            if (trigger == null) return;
            trigger.transform.localScale = new Vector3(_attackRange, _attackRange, 1f);
        }
    }

    [Serializable]
    public struct AllyBattleParameter
    {
        [SerializeField]
        private float _maxLife;
        [SerializeField]
        private float _attackPower;
        [SerializeField]
        private int _maxTargetCount;
        [SerializeField]
        private float _attackRange;
        [SerializeField]
        private float _attackInterval;

        public AllyBattleParameter(float maxLife, float attackPower, int maxTargetCount, float attackRange, float attackInterval)
        {
            _maxLife = maxLife;
            _attackPower = attackPower;
            _maxTargetCount = maxTargetCount;
            _attackRange = attackRange;
            _attackInterval = attackInterval;
        }

        public float MaxLife => _maxLife;
        public float AttackPower => _attackPower;
        public float MaxTargetCount => _maxTargetCount;
        public float AttackRange => _attackRange;
        public float AttackInterval => _attackInterval;

        public static AllyBattleParameter operator +(AllyBattleParameter left, AllyBattleParameter right)
        {
            AllyBattleParameter result = new AllyBattleParameter();

            result._maxLife = left._maxLife + right._maxLife;
            result._attackPower = left._attackPower + right._attackPower;
            result._maxTargetCount = left._maxTargetCount + right._maxTargetCount;
            result._attackRange = left._attackRange + right._attackRange;
            result._attackInterval = left._attackInterval + right._attackInterval;

            return result;
        }

        public static AllyBattleParameter operator *(AllyBattleParameter left, float multiplier)
        {
            AllyBattleParameter result = new AllyBattleParameter();

            result._maxLife = left._maxLife * multiplier;
            result._attackPower = left._attackPower * multiplier;
            result._maxTargetCount = (int)(left._maxTargetCount * multiplier);
            result._attackRange = left._attackRange * multiplier;
            result._attackInterval = left._attackInterval * multiplier;

            return result;
        }

        public static AllyBattleParameter operator *(AllyBattleParameter left, AllyBattleParameter right)
        {
            AllyBattleParameter result = new AllyBattleParameter();

            result._maxLife = left._maxLife * right._maxLife;
            result._attackPower = left._attackPower * right._attackPower;
            result._maxTargetCount = left._maxTargetCount * right._maxTargetCount;
            result._attackRange = left._attackRange * right._attackRange;
            result._attackInterval = left._attackInterval * right._attackInterval;

            return result;
        }

        // 指定されないパラメータは0で初期化される。(足し算用)
        public static AllyBattleParameter CreateZero(float maxLife = 0f, float attackPower = 0f, int maxTargetCount = 0, float attackRange = 0f, float attackInterval = 0f)
        {
            AllyBattleParameter result = new AllyBattleParameter
            {
                _maxLife = maxLife,
                _attackPower = attackPower,
                _maxTargetCount = maxTargetCount,
                _attackRange = attackRange,
                _attackInterval = attackInterval
            };

            return result;
        }

        // 指定されないパラメータは1で初期化される。(掛け算用)
        public static AllyBattleParameter CreateOne(float maxLife = 1f, float attackPower = 1f, int maxTargetCount = 1, float attackRange = 1f, float attackInterval = 1f)
        {
            AllyBattleParameter result = new AllyBattleParameter
            {
                _maxLife = maxLife,
                _attackPower = attackPower,
                _maxTargetCount = maxTargetCount,
                _attackRange = attackRange,
                _attackInterval = attackInterval
            };

            return result;
        }
    }

    public static class Converter
    {
        public static AllyBattleParameter ToAllyBattleParameter(this AllyConstantParameter parameter)
        {
            AllyBattleParameter result =
                new AllyBattleParameter(parameter.MaxLife, parameter.AttackPower, parameter.MaxTargetCount, parameter.AttackRange, parameter.AttackInterval);

            return result;
        }
    }
}
