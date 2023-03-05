using System.Collections;
using UnityEngine;

namespace StateMachine.test
{
    public class MoveToNormal : ITransition<Tester>
    {
        public MoveToNormal(Tester manager, string previousStateName, string nextStateName) : base(manager, previousStateName, nextStateName)
        {
        }

        protected override void Action()
        {
            
        }

        protected override bool Condition()
        {
            return manager.A == false;
        }
    }
}