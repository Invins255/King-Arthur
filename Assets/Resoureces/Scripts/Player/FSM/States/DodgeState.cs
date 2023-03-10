using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;
using PlayerControl;

namespace PlayerControl
{
    public class DodgeState : IState<PlayerController>
    {
        public DodgeState(PlayerController manager) : base(manager)
        {
        }

        public override void OnAnimatorMove()
        {
            manager.Animator.ApplyBuiltinRootMotion();
        }

        public override void OnEnter()
        {
            base.OnEnter();

            if(manager.Input.dodge)
                MakeDodge();         
        }

        public override void OnExit()
        {
            base.OnExit();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
        }

        private void MakeDodge()
        {
            manager.Animator.SetTrigger(manager.AnimID["Dodge"]);
            manager.Input.dodge = false;
        }
    }
}
