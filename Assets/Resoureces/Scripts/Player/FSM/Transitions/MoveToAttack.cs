using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace PlayerControl
{
    public class MoveToAttack : ITransition<PlayerController>
    {
        public MoveToAttack(PlayerController manager, string previousStateName, string nextStateName) : base(manager, previousStateName, nextStateName)
        {
        }

        protected override void Action()
        {

        }

        protected override bool Condition()
        {
            //Get Attack input
            if (manager.Input.lightAttack || manager.Input.heavyAttack)
            {
                return true;
            }
            return false;
        }
    }
}