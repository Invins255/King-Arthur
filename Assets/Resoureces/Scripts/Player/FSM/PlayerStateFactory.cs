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

            IsBuilt = true;
            return states;
        }
    }
}
