using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine.test
{
    public class NormalStateFactory : IStateFactory<Tester>
    {
        public NormalStateFactory(Tester manager) : base(manager)
        {
        }

        public override Dictionary<string, IState<Tester>> CreateStates()
        {
            Dictionary<string, IState<Tester>> states = new Dictionary<string, IState<Tester>>();

            IdleState idleState = new IdleState(manager);
            states.Add("IdleState", idleState);

            IsBuilt = true;
            return states;

        }
    }
}