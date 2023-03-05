using System.Collections;
using UnityEngine;

namespace StateMachine.test
{
    public class WalkToRun : ITransition<Tester>
    {
        public WalkToRun(Tester manager, string previousStateName, string nextStateName) : base(manager, previousStateName, nextStateName)
        {
        }

        protected override void Action()
        {
            
        }

        protected override bool Condition()
        {
            return manager.D == true;
        }
    }
}