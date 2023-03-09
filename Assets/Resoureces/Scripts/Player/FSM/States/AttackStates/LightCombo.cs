using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace PlayerControl
{
    public class LightCombo : IState<PlayerController>
    {
        public LightCombo(PlayerController manager) : base(manager)
        {
        }

        public override void OnAnimatorMove()
        {
            manager.Animator.ApplyBuiltinRootMotion();
        }

        public override void OnEnter()
        {
            base.OnEnter();

            //��ɴ��ⲿ״̬���빥��״̬ʱ�Ĺ�������
            if (manager.Input.lightAttack)
            {
                manager.Attacker.HandleLightAttack(manager.WeaponManager.RightWeapon);
                manager.Input.lightAttack = false;
            }
        }

        public override void OnExit()
        {
            //���ö���Ĺ������� 
            manager.Animator.ResetTrigger(manager.AnimID["LightAttack"]);
            base.OnExit();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (manager.Input.lightAttack)
            {
                manager.Attacker.HandleLightAttack(manager.WeaponManager.RightWeapon);
                manager.Input.lightAttack = false;
            }
        }
    }
}