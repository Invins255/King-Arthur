using System.Collections;
using UnityEngine;

namespace StateMachine.test
{
    public class RunToWalk : ITransition<Tester>
    {
        public RunToWalk(Tester manager, string previousStateName, string nextStateName) : base(manager, previousStateName, nextStateName)
        {
        }

        protected override void Action()
        {
            
        }

        protected override bool Condition()
        {
            return manager.D == false;
        }
    }
}