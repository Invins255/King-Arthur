using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine.test
{
    public class TestStateFactory : IStateFactory<Tester>
    {
        public TestStateFactory(Tester manager) : base(manager)
        {
        }

        public override Dictionary<string, IState<Tester>> CreateStates()
        {
            Dictionary<string, IState<Tester>> states = new Dictionary<string, IState<Tester>>();

            NormalStateFactory normalStateFactory = new NormalStateFactory(manager);
            NormalState normalState = new NormalState(manager, normalStateFactory);
            normalState.AddTransition(new NormalToMove(manager, "NormalState", "MoveState"));
            normalState.SetDefaultState("IdleState", false);
            states.Add("NormalState", normalState);

            MoveStateFactory moveStateFactory = new MoveStateFactory(manager);
            MoveState moveState = new MoveState(manager, moveStateFactory);
            moveState.AddTransition(new MoveToNormal(manager, "MoveState", "NormalState"));
            moveState.SetDefaultState("WalkState", false);
            states.Add("MoveState", moveState);


            IsBuilt = true;
            return states;
        }
    }
}