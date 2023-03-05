using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine {
    /// <summary>
    /// ״̬���ɳ����࣬����������ʱ����ת����һ״̬, ʵ��״̬��Ĺ���
    /// </summary>
    /// <typeparam name="T">������״̬���������</typeparam>
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
        /// ������⣬��������ʱ����״̬��ת
        /// </summary>
        /// <param name="nextState">��һ״̬��</param>
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
        /// ���������������н���ʵ��
        /// </summary>
        /// <returns></returns>
        protected abstract bool Condition();

        /// <summary>
        /// �ù��ɷ���ʱӦ���е���Ϊ�������н���ʵ��
        /// </summary>
        /// <returns></returns>
        protected abstract void Action();
    }
}