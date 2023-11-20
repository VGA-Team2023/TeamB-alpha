using Glib.InspectorExtension;
using UnityEngine;
using System;

namespace TeamB_TD
{
    namespace Battle
    {
        namespace Unit
        {
            namespace Ally
            {
                [Serializable]
                public class AllyAttackController
                {
                    [SerializeReference, SubclassSelector]
                    private IAllyAttack _allyAttack;

                    private AllyController _controller;

                    private WaitingState _waitingState = null;
                    private AttackingState _attackingState = null;
                    private IntervalState _intervalState = null;

                    private AttackState _currentState = null;

                    public IAllyAttack CurrentAttackStyle => _allyAttack;
                    public AllyController AllyController => _controller;

                    public AttackState CurrentState => _currentState;

                    public void Initialize(AllyController controller)
                    {
                        _controller = controller;

                        _waitingState = new WaitingState(this);
                        _attackingState = new AttackingState(this);
                        _intervalState = new IntervalState(this);

                        _waitingState.AttackState = _attackingState;
                        _attackingState.IntervalState = _intervalState;
                        _intervalState.WaitingState = _waitingState;

                        Transition(_waitingState);
                    }

                    public void Update()
                    {
                        if (_currentState != null)
                            _currentState.Update();
                        else
                            Debug.Log(nameof(_currentState) + " is null...");
                    }

                    public void ChangeAttackStyle(IAllyAttack attack)
                    {
                        Debug.Log("change attack style");
                        _allyAttack = attack;
                        Transition(_waitingState);
                    }

                    public void Transition(AttackState attackState)
                    {
                        _currentState?.Exit();
                        _currentState = attackState;
                        _currentState?.Enter();
                    }

                    public abstract class AttackState
                    {
                        public virtual void Enter() { }
                        public virtual void Update() { }
                        public virtual void Exit() { }
                    }

                    private class WaitingState : AttackState
                    {
                        public WaitingState(AllyAttackController controller, AttackingState attackState = null)
                        {
                            Controller = controller;
                            AttackState = attackState;
                        }

                        public AllyAttackController Controller { get; set; }
                        public AttackingState AttackState { get; set; }

                        public override void Update()
                        {
                            if (Controller.CurrentAttackStyle == null) return; // throw new ArgumentNullException(nameof(Controller.CurrentAttackStyle));

                            if (Controller.CurrentAttackStyle.IsAnyObjectInTrigger())
                            {
                                Controller.Transition(AttackState);
                            }
                        }
                    }

                    private class AttackingState : AttackState
                    {
                        public AttackingState(AllyAttackController controller, IntervalState intervalState = null)
                        {
                            IntervalState = intervalState;
                            Controller = controller;
                        }

                        public AllyAttackController Controller { get; set; }
                        public IntervalState IntervalState { get; set; }

                        private float _timer = 0f;

                        private float AttackPower => Controller.AllyController.Param.AttackPower;

                        public override void Enter()
                        {
                            // Debug.Log($"{Controller.CurrentAttackStyle.GetType().Name} Fire!");
                            Controller.CurrentAttackStyle.Fire(AttackPower);
                            _timer = 0f;
                        }

                        public override void Update()
                        {
                            _timer += Time.deltaTime * GameSpeedController.CurretGameSpeed;

                            if (Controller.CurrentAttackStyle == null) return; // throw new ArgumentNullException(nameof(Controller.CurrentAttackStyle));

                            if (_timer > Controller.CurrentAttackStyle.AttackAnimationTime)
                            {
                                Controller.Transition(IntervalState);
                            }
                        }
                    }

                    private class IntervalState : AttackState
                    {
                        public IntervalState(AllyAttackController controller, WaitingState waitingState = null)
                        {
                            WaitingState = waitingState;
                            AttackController = controller;
                        }

                        public AllyAttackController AttackController { get; set; }
                        public WaitingState WaitingState { get; set; }

                        private float _timer = 0f;

                        private float AttackInterval => AttackController.AllyController.Param.AttackInterval;

                        public override void Enter()
                        {
                            _timer = 0f;
                        }

                        public override void Update()
                        {
                            _timer += Time.deltaTime * GameSpeedController.CurretGameSpeed;

                            if (_timer > AttackInterval)
                            {
                                AttackController.Transition(WaitingState);
                            }
                        }
                    }
                }
            }
        }
    }
}