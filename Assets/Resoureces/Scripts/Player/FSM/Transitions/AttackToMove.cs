using StateMachine;
using System.Collections;
using UnityEngine;

namespace PlayerControl
{
    public class AttackToMove : ITransition<PlayerController>
    {
        public AttackToMove(PlayerController manager, string previousStateName, string nextStateName) : base(manager, previousStateName, nextStateName)
        {
        }

        protected override void Action()
        {

        }

        protected override bool Condition()
        {
            //基于Animator当前transition名确定是否退出Attack State
            var info = manager.Animator.GetAnimatorTransitionInfo(1);
            if (info.IsUserName("AttackExit"))
            {
                return true;
            }
            return false;
        }
    }
}