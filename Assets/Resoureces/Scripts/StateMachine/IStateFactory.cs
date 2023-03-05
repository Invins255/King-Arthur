using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    /// <summary>
    /// 状态集合工厂，为状态机创建状态字典
    /// </summary>
    public abstract class IStateFactory<T>
    {
        public bool IsBuilt { get; set; }

        protected T manager;

        public IStateFactory(T manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// 构建状态字典，决定状态机所拥有的状态，子类中实现（工厂方法模式 ）。该方法中应完成一个状态机状态对象、状态过渡对象的建立，若一个状态同时为子状态机，还应完成默认状态的设置
        /// </summary>
        /// <returns>状态字典</returns>
        public abstract Dictionary<string, IState<T>> CreateStates();
    }
}