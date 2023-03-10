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
                manager.Attacker.HandleHeavyAttack(manager.WeaponManager.Weapon);
                manager.Input.heavyAttack = false;
            }
        }

        public override void OnExit()
        {
            //重置多余的攻击触发 
            manager.Animator.ResetTrigger(manager.AnimID["HeavyAttack"]);

            base.OnExit();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (manager.Input.heavyAttack)
            {
                manager.Attacker.HandleHeavyAttack(manager.WeaponManager.Weapon);
                manager.Input.heavyAttack = false;
            }
        }
    }
}