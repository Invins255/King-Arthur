using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace PlayerControl
{
    public class AttackState : IStateMachine<PlayerController>
    {
        public AttackState(PlayerController manager, IStateFactory<PlayerController> statefactory) : base(manager, statefactory)
        {
        }

        public override void OnAnimatorMove()
        {
            base.OnAnimatorMove();
        }

        public override void OnEnter()
        {
            //Change attack substate by attack input
            if (manager.Input.lightAttack)
                SetDefaultState("LightCombo");
            else if (manager.Input.heavyAttack)
                SetDefaultState("HeavyAttack");

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