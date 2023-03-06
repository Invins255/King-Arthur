using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace PlayerControl
{
    public class DodgeToMove : ITransition<PlayerController>
    {
        public DodgeToMove(PlayerController manager, string previousStateName, string nextStateName) : base(manager, previousStateName, nextStateName)
        {
        }

        protected override void Action()
        {

        }

        protected override bool Condition()
        {
            //基于Animator当前transition名确定是否退出Attack State
            var info = manager.Animator.GetAnimatorTransitionInfo(0);
            if (info.IsUserName("DodgeExit"))
            {
                return true;
            }
            return false;
        }
    }

}
