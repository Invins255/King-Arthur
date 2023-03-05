using System.Collections;
using UnityEngine;

namespace StateMachine.test
{
    public class TestStateMachine : IStateMachine<Tester>
    {
        public TestStateMachine(Tester manager, IStateFactory<Tester> statefactory) : base(manager, statefactory)
        {
        }
    }
}