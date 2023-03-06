using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;
using StateMachine.test;

namespace PlayerControl
{
    public class PlayerStateFactory : IStateFactory<PlayerController>
    {
        public PlayerStateFactory(PlayerController manager) : base(manager)
        {
        }

        public override Dictionary<string, IState<PlayerController>> CreateStates()
        {
            Dictionary<string, IState<PlayerController>> states = new Dictionary<string, IState<PlayerController>>();

            //为PlayerController创建状态与过渡条件
            MoveState moveState = new MoveState(manager);
            states.Add("MoveState", moveState);
            moveState.AddTransition(new MoveToAttack(manager, "MoveState", "AttackState"));
            moveState.AddTransition(new MoveToDodge(manager, "MoveState", "DodgeState"));

            AttackStateFactory attackStateFactory = new AttackStateFactory(manager);
            AttackState attackState = new AttackState(manager, attackStateFactory);
            states.Add("AttackState", attackState);
            attackState.AddTransition(new AttackToMove(manager, "AttackState", "MoveState"));

            DodgeState dodgeState = new DodgeState(manager);
            states.Add("DodgeState", dodgeState);
            dodgeState.AddTransition(new DodgeToMove(manager, "DodgeState", "MoveState"));

            IsBuilt = true;
            return states;
        }
    }
}
