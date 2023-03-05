using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    /// <summary>
    /// 状态机抽象类，作为需要进行状态管理的对象的组件，同时也是一个状态（分层状态机），因此当需要建立一个子状态机时，应继承该类
    /// </summary>
    /// <typeparam name="T">被管理状态对象的类型</typeparam>
    public abstract class IStateMachine<T> : IState<T>
    {
        public IState<T> PreviousState { get; private set; }
        public IState<T> CurrentState { get; private set; }
        public IState<T> DefaultState { get; private set; }

        public void DebugStatesTransition(bool value)
        {
            debugTransition = value;
        }
        private bool debugTransition = false;
        /// <summary>
        /// 子状态集合
        /// </summary>
        private Dictionary<string, IState<T>> states = new Dictionary<string, IState<T>>();

        /// <summary>
        /// 为该状态机定制状态集合的工厂
        /// </summary>
        private IStateFactory<T> statefactory;

        public IStateMachine(T manager, IStateFactory<T> statefactory) : base(manager)
        {
            this.statefactory = statefactory;
            states = statefactory.CreateStates();
        }

        public override void OnAnimatorMove()
        {
            base.OnAnimatorMove();

            CurrentState.OnAnimatorMove();
        }

        /// <summary>
        /// 若为根状态机，应在Awake/Start中设置默认状态并进入状态机。
        /// 如果希望在OnEnter时动态设置默认状态，应在base.OnEnter()前执行。
        /// </summary>
        public override void OnEnter()
        {
            base.OnEnter();
            //进入默认状态
            if (DefaultState != null)
            {
                ChangeState(DefaultState);
            }
            else
            {
                Debug.LogError($"There is no default state in State Machine {StateName}!");
            }

        }

        public override void OnExit()
        {
            //退出当前状态
            if (CurrentState != null)
            {
                CurrentState.OnExit();
                CurrentState = null;
            }
            base.OnExit();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (CurrentState == null)
                return;

            //更新当前状态
            CurrentState.OnUpdate();

            //检查是否满足状态过渡条件
            if(CurrentState.CheckTransitions(out string nextStateName))
            {
                IState<T> state = GetState(nextStateName);
                if (state != null)
                {
                    ChangeState(state);
                }
            }
        }

        public IState<T> GetState(string stateName)
        {
            if(states.TryGetValue(stateName, out IState<T> state))
            {
                return state;
            }
            else
            {
                Debug.LogError($"ERROR: {stateName} is not exist in State Machine {StateName}! Please check the state name or check whether the state is added.");
                return null;
            }
        }

        private void ChangeState(IState<T> nextState)
        {
            if (CurrentState != null)
            {
                if (debugTransition)
                    Debug.Log($"{CurrentState.StateName} On Exit.");
                
                CurrentState.OnExit();                
            }
            if(nextState != null)
            {
                CurrentState = nextState;
                CurrentState.OnEnter();

                if(debugTransition)
                    Debug.Log($"{CurrentState.StateName} On Enter.");
            }
        }

        public void SetDefaultState(string stateName, bool startImmediately = false)
        {
            IState<T> state = GetState(stateName);
            if(state != null)
            {
                DefaultState = state;
                if (startImmediately)
                {
                    ChangeState(DefaultState);
                }
            }
        }
    }
}