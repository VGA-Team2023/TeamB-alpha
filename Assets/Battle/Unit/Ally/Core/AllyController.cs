using System;
using System.Collections.Generic;
using TeamB_TD.Battle.StageManagement;
using UnityEngine;

namespace TeamB_TD
{
    namespace Battle
    {
        namespace Unit
        {
            namespace Ally
            {
                public class AllyController : MonoBehaviour, IAllyDamageable
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
                    private SpriteRenderer[] _myRenderers = null;
                    private int[] _myRenderersOrder = null;

                    public AllyConstantParameter ConstantParams => _constantParam;
                    public string Name => _name;
                    public Vector3 WorldPosition => transform.position;
                    public AllyLifeController LifeController => _lifeController;
                    public AllyAttackController AttackController => _attackController;
                    public List<AllyBattleParameter> AddParams => _addParams;
                    public List<AllyBattleParameter> MultiplierParams => _multiplierParams;
                    public SpriteRenderer[] Renderers => _myRenderers;
                    public int[] RenderersOrder => _myRenderersOrder;
                    public IStageCell GroundCell { get; set; }

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

                    private void Awake()
                    {
                        _myRenderers = GetComponentsInChildren<SpriteRenderer>();
                        _myRenderersOrder = new int[_myRenderers.Length];

                        for (int i = 0; i < _myRenderers.Length; i++)
                        {
                            _myRenderersOrder[i] = _myRenderers[i].sortingOrder;
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

                        var screenPos = Camera.main.WorldToScreenPoint(transform.position);
                        VFXManager.Current.RequestDamageVFX(value, screenPos);
                    }

                    public void UpdateOrderInLayer(int order)
                    {
                        for (int i = 0; i < _myRenderersOrder.Length; i++)
                        {
                            _myRenderers[i].sortingOrder = _myRenderersOrder[i] + order;
                        }
                    }

                    public void UpdateOrderInLayer(int[] orders)
                    {
                        for (int i = 0; i < orders.Length; i++)
                        {
                            _myRenderers[i].sortingOrder = _myRenderersOrder[i] + orders[i];
                        }
                    }
                }
            }
        }
    }
}