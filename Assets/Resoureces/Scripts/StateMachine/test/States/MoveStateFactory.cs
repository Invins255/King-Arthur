using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine.test
{
    public class MoveStateFactory : IStateFactory<Tester>
    {
        public MoveStateFactory(Tester manager) : base(manager)
        {
        }

        public override Dictionary<string, IState<Tester>> CreateStates()
        {
            Dictionary<string, IState<Tester>> states = new Dictionary<string, IState<Tester>>();

            WalkState walkState = new WalkState(manager);
            walkState.AddTransition(new WalkToRun(manager, "WalkState", "RunState"));
            states.Add("WalkState", walkState);

            RunState runState = new RunState(manager);
            runState.AddTransition(new RunToWalk(manager, "RunState", "WalkState"));
            states.Add("RunState", runState);

            IsBuilt = true;
            return states;

        }
    }
}