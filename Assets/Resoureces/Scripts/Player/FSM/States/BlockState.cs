using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace PlayerControl
{
    public class BlockState : IState<PlayerController>
    {
        public BlockState(PlayerController manager) : base(manager)
        {
        }

        public override void OnAnimatorMove()
        {
            base.OnAnimatorMove();
        }

        public override void OnEnter()
        {
            base.OnEnter();
            manager.Animator.Play("TwohandedSword_BlockBegin");
            manager.WeaponManager.OpenBlockCollider();
        }

        public override void OnExit()
        {
            manager.WeaponManager.CloseBlockCollider();
            base.OnExit();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            manager.Animator.SetBool("IsBlocking", manager.Input.isBlocking);

            while (manager.DamageMessageQueue.Count > 0)
            {
                DamageMessage message = manager.DamageMessageQueue.Dequeue();
                ProcessDamageMessage(message);

                if (manager.Stats.CurrentHealth < 0)
                {
                    manager.DamageMessageQueue.Clear();
                    break;
                }
            }
        }

        private void ProcessDamageMessage(DamageMessage damageMessage)
        {
            Debug.Log($"{manager.gameObject.name} is attacked by {damageMessage.Attacker.name}. Message: {damageMessage.Message}");

            int finalDamage = Mathf.RoundToInt(damageMessage.Weapon.Damage * (1.0f - manager.WeaponManager.BlockCollider.BlockingDamageAbsorption));

            manager.Stats.TakeDamage(finalDamage);
        }
    }
}