using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;


namespace PlayerControl
{
    public class PlayerStateMachine : IStateMachine<PlayerController>
    {
        public PlayerStateMachine(PlayerController manager, IStateFactory<PlayerController> statefactory) : base(manager, statefactory)
        {
        }
    }
}
