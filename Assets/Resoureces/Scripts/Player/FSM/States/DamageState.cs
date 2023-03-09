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
            manager.Animator.ApplyBuiltinRootMotion();
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

            while(manager.DamageMessageQueue.Count > 0)
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

            //计算Attacker到自身的水平方向
            Vector3 dir = -manager.transform.InverseTransformPoint(damageMessage.Attacker.transform.position);
            dir.y = 0.0f;
            dir = dir.normalized;

            manager.Animator.SetFloat("HitX", dir.x);
            manager.Animator.SetFloat("HitY", dir.z);
            manager.Animator.SetTrigger("Hit");

            manager.Stats.TakeDamage(damageMessage.Weapon.Damage);
        }
    }
}