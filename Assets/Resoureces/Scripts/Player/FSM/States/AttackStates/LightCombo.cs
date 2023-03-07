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
                MakeAttack();
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
                MakeAttack();
            }
        }

        private void MakeAttack()
        {
            manager.Animator.SetTrigger(manager.AnimID["LightAttack"]);
            manager.Input.lightAttack = false;

            DamageMessage message = new DamageMessage();
            message.Message = "Player light attack";
            message.Attacker = manager.gameObject;
            message.Weapon = manager.Inventory.RightWeapon;
            manager.Inventory.WeaponSlotManager.SetRightWeaponDamageMessage(message);
        }
    }
}