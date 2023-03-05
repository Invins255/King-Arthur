using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerControl
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {
        public PlayerDataSO PlayerData;

        [Header("Move")]
        public float CurrentHorizontalSpeed;
        public float CurrentVerticalSpeed;

        [Header("Animator parameter IDs")]
        public string[] AnimParams;
        //Animation hash IDs
        public Dictionary<string, int> AnimID = new Dictionary<string, int>();

        //Components
        private PlayerStateMachine stateMachine;
        public PlayerInputs Input { get { return _input; } }
        private PlayerInputs _input;
        public CharacterController Controller { get { return _controller; } }
        private CharacterController _controller;
        public Animator Animator { get { return _animator; } }
        private Animator _animator;
        public GameObject MainCamera { get { return _mainCamera; } }
        private GameObject _mainCamera;

        private void Awake()
        {
            //Create statemachine
            PlayerStateFactory stateFactory = new PlayerStateFactory(this);
            stateMachine = new PlayerStateMachine(this, stateFactory);

            //Get components
            _input = GetComponent<PlayerInputs>();
            _controller = GetComponent<CharacterController>();
            _animator = GetComponent<Animator>();
            _mainCamera = GameObject.FindGameObjectWithTag("MainCamera");

            AssignAnimationIDs();

            //Set default state
            stateMachine.SetDefaultState("MoveState");
            stateMachine.OnEnter();
        }

        void Update()
        {
            stateMachine.OnUpdate();
        }

        private void OnAnimatorMove()
        {
            stateMachine.OnAnimatorMove();
        }

        /// <summary>
        /// 登记动画状态hash值ID，使用ID查询动画状态以提高效率
        /// </summary>
        private void AssignAnimationIDs()
        {
            foreach (string name in AnimParams)
            {
                AnimID.Add(name, Animator.StringToHash(name));
            }
        }
    }

}