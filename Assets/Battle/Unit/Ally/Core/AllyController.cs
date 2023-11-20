using System;
using System.Collections.Generic;
using Glib.InspectorExtension;
using UnityEngine;

namespace TeamB_TD
{
    namespace Battle
    {
        namespace Unit
        {
            namespace Ally
            {
                public class AllyController : MonoBehaviour, IDamageable
                {
                    [SerializeField]
                    private AllyConstantParameter _constantParam = default;
                    [SerializeField]
                    private string _name;
                    [SerializeField]
                    private AllyLifeController _lifeController;
                    [SerializeField]
                    private AllyAttackController _attackController;

                    private AllyBattleParameter _baseParam;
                    private List<AllyBattleParameter> _addParams = new List<AllyBattleParameter>(); // バフ、デバフ用、足し算。
                    private List<AllyBattleParameter> _multiplierParams = new List<AllyBattleParameter>(); // バフ、デバフ用、掛け算。

                    public AllyConstantParameter ConstantParams => _constantParam;
                    public string Name => _name;
                    public Vector3 WorldPosition => transform.position;
                    public AllyLifeController LifeController => _lifeController;
                    public AllyAttackController AttackController => _attackController;
                    public List<AllyBattleParameter> AddParams => _addParams;
                    public List<AllyBattleParameter> MultiplierParams => _multiplierParams;

                    public event Action<AllyController> OnDeadAlly;
                    public event Action<IDamageable> OnDead;


                    public AllyBattleParameter TotalParam
                    {
                        get
                        {
                            AllyBattleParameter result = _baseParam;
                            for (int i = 0; i < _addParams.Count; i++)
                            {
                                result += _addParams[i];
                            }
                            for (int i = 0; i < _multiplierParams.Count; i++)
                            {
                                result *= _multiplierParams[i];
                            }
                            return result;
                        }
                    }

                    private void Start()
                    {
                        _baseParam = _constantParam.ToAllyBattleParameter();
                        _lifeController.Initialize(this);
                        _attackController.Initialize(this);
                    }

                    private void Update()
                    {
                        _attackController.Update();
                    }

                    private void OnDestroy()
                    {
                        OnDead?.Invoke(this);
                        OnDeadAlly?.Invoke(this);
                    }

                    public void Damge(float value)
                    {
                        _lifeController.Damge(value);
                    }
                }
            }
        }
    }
}