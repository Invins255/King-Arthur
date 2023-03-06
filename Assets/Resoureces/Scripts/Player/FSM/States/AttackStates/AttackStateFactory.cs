using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;


namespace PlayerControl
{
    public class AttackStateFactory : IStateFactory<PlayerController>
    {
        public AttackStateFactory(PlayerController manager) : base(manager)
        {
        }

        public override Dictionary<string, IState<PlayerController>> CreateStates()
        {
            Dictionary<string, IState<PlayerController>> states = new Dictionary<string, IState<PlayerController>>();

            LightCombo lightCombo = new LightCombo(manager);
            states.Add("LightCombo", lightCombo);

            HeavyAttack heavyAttack = new HeavyAttack(manager);
            states.Add("HeavyAttack", heavyAttack);

            IsBuilt = true;
            return states;
        }

    }
}