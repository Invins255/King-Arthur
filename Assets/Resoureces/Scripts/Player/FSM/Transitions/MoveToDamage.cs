using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace PlayerControl
{
    public class MoveToDamage : ITransition<PlayerController>
    {
        public MoveToDamage(PlayerController manager, string previousStateName, string nextStateName) : base(manager, previousStateName, nextStateName)
        {
        }

        protected override void Action()
        {

        }

        protected override bool Condition()
        {
            return manager.DamageMessageQueue.Count > 0;
        }
    }
}