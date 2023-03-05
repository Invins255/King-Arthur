using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine {
    /// <summary>
    /// 状态过渡抽象类，当条件满足时，跳转至下一状态, 实现状态间的过渡
    /// </summary>
    /// <typeparam name="T">被管理状态对象的类型</typeparam>
    public abstract class ITransition<T> 
    {
        protected T manager;

        protected ITransition(T manager, string previousStateName, string nextStateName)
        {
            this.manager = manager;
            PreviousStateName = previousStateName;
            NextStateName = nextStateName;
        }

        public string PreviousStateName { get; private set; }
        public string NextStateName { get; private set; }

        /// <summary>
        /// 条件检测，满足条件时进行状态跳转
        /// </summary>
        /// <param name="nextState">下一状态名</param>
        public bool CheckCondition(out string nextState)
        {
            nextState = string.Empty;
            if (Condition())
            {
                nextState = NextStateName;
                Action();
                return true;
            }

            return false;
        }

        /// <summary>
        /// 条件函数，子类中进行实现
        /// </summary>
        /// <returns></returns>
        protected abstract bool Condition();

        /// <summary>
        /// 该过渡发生时应进行的行为，子类中进行实现
        /// </summary>
        /// <returns></returns>
        protected abstract void Action();
    }
}