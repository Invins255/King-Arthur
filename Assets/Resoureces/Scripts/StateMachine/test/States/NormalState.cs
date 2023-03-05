using System.Collections;
using UnityEngine;

namespace StateMachine.test
{
    public class NormalState : IStateMachine<Tester>
    {
        public NormalState(Tester manager, IStateFactory<Tester> statefactory) : base(manager, statefactory)
        {
        }

        public override void OnAnimatorMove()
        {
            base.OnAnimatorMove();
        }

        public override void OnEnter()
        {
            base.OnEnter();
        }

        public override void OnExit()
        {
            base.OnExit();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
        }
    }
}