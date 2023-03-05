using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine.test {
    public class NormalToMove : ITransition<Tester>
    {
        public NormalToMove(Tester manager, string previousStateName, string nextStateName) : base(manager, previousStateName, nextStateName)
        {
        }

        protected override void Action()
        {

        }

        protected override bool Condition()
        {
            return manager.A == true;
        }
    }
}