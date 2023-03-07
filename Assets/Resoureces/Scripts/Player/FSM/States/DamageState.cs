using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace PlayerControl
{
    public class DamageState : IState<PlayerController>
    {
        public DamageState(PlayerController manager) : base(manager)
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