using System.Collections;
using UnityEngine;

namespace StateMachine.test
{
    public class Tester : MonoBehaviour
    {
        private TestStateMachine RootStateMachine;

        public bool A;
        public bool D;

        private void Awake()
        {
            TestStateFactory stateFactory = new TestStateFactory(this);
            RootStateMachine = new TestStateMachine(this, stateFactory);

            RootStateMachine.SetDefaultState("NormalState", false);
            RootStateMachine.OnEnter();
        }

        void Start()
        {
            A = false;
            D = false;
        }

        void Update()
        {
            
            RootStateMachine.OnUpdate();
        }
    }
}