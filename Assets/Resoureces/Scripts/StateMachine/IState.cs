using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    public abstract class IState<T>
    {
        public string StateName { get; private set; }
        protected T manager;

        public IState(T manager)
        {
            this.manager = manager;
            StateName = GetType().Name;
        }

        protected List<ITransition<T>> Transitions
        {
            get
            {
                if (transitions == null)
                    transitions = new List<ITransition<T>>();
                return transitions;
            }
        }
        private List<ITransition<T>> transitions;

        public virtual void OnEnter() { /*Debug.Log($"{StateName} On Enter");*/ }
        public virtual void OnUpdate() { /*Debug.Log($"{StateName} On Update");*/ }
        public virtual void OnAnimatorMove() { /*Debug.Log($"{StateName} On AnimatorMove");*/ }
        public virtual void OnExit() { /*Debug.Log($"{StateName} On Exit");*/ }
    
        /// <summary>
        /// 添加新的过渡
        /// </summary>
        /// <param name="transition">过渡</param>
        public void AddTransition(ITransition<T> transition)
        {
            if (Transitions == null)
                return;

            Transitions.Add(transition);
        }

        /// <summary>
        /// 轮询各个过渡，检测是否存在被满足的条件，进行状态过渡(若存在多个被满足的条件，优先执行顺序较前的过渡)
        /// </summary>
        /// <param name="nextStateName">下一状态名</param>
        public virtual bool CheckTransitions(out string nextStateName)
        {
            nextStateName = string.Empty;
            foreach(var transition in Transitions)
            {
                if(transition.CheckCondition(out nextStateName))
                {
                    return true;
                }
            }
            return false;
        }

    }
}