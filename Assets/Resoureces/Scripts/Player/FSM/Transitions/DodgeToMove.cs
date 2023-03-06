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
            //����Animator��ǰtransition��ȷ���Ƿ��˳�Attack State
            var info = manager.Animator.GetAnimatorTransitionInfo(0);
            if (info.IsUserName("DodgeExit"))
            {
                return true;
            }
            return false;
        }
    }

}
