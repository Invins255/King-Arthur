using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace PlayerControl
{
    public class HeavyAttack : IState<PlayerController>
    {
        public HeavyAttack(PlayerController manager) : base(manager)
        {
        }

        public override void OnAnimatorMove()
        {
            manager.Animator.ApplyBuiltinRootMotion();
        }

        public override void OnEnter()
        {
            base.OnEnter();
            if (manager.Input.heavyAttack)
            {
                MakeAttack();
            }
        }

        public override void OnExit()
        {
            //���ö���Ĺ������� 
            manager.Animator.ResetTrigger(manager.AnimID["HeavyAttack"]);

            base.OnExit();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
        }

        private void MakeAttack()
        {
            manager.Animator.SetTrigger(manager.AnimID["HeavyAttack"]);
            manager.Input.heavyAttack = false;
        }
    }
}