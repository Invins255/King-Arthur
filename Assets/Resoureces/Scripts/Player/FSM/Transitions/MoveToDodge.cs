using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace PlayerControl
{
    public class MoveToDodge : ITransition<PlayerController>
    {
        public MoveToDodge(PlayerController manager, string previousStateName, string nextStateName) : base(manager, previousStateName, nextStateName)
        {
        }

        protected override void Action()
        {

        }

        protected override bool Condition()
        {
            if(manager.Input.dodge)
                return true;
            return false;
        }
    }
}