using System.Collections;
using UnityEngine;

namespace StateMachine.test
{
    public class MoveState : IStateMachine<Tester>
    {
        public MoveState(Tester manager, IStateFactory<Tester> statefactory) : base(manager, statefactory)
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