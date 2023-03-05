using System.Collections;
using UnityEngine;

namespace StateMachine.test
{
    public class IdleState : IState<Tester>
    {
        public IdleState(Tester manager) : base(manager)
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