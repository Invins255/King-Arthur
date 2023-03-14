using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

namespace PlayerControl
{
    public class PlayerController : MonoBehaviour
    {
        public PlayerDataSO PlayerData;

        [Header("Move")]
        public float CurrentHorizontalSpeed;
        public float CurrentVerticalSpeed;

        [Header("Interact")]
        public float InteractRadius = 1.0f;

        [Header("Animator parameter IDs")]
        public string[] AnimParams;
        //Animation hash IDs
        public Dictionary<string, int> AnimID = new Dictionary<string, int>();

        [HideInInspector]
        public Queue<DamageMessage> DamageMessageQueue = new Queue<DamageMessage>();

        //Components
        private PlayerStateMachine stateMachine;
        public PlayerInputs Input { get { return _input; } }
        private PlayerInputs _input;
        public PlayerStats Stats { get { return _stats; } }
        private PlayerStats _stats;
        public CharacterController Controller { get { return _controller; } }
        private CharacterController _controller;
        public Animator Animator { get { return _animator; } }
        private Animator _animator;
        public GameObject MainCamera { get { return _mainCamera; } }
        private GameObject _mainCamera;
        public WeaponManager WeaponManager { get { return _weaponManager; } }
        private WeaponManager _weaponManager;
        public Attacker Attacker { get { return _attacker; } }
        private Attacker _attacker;

        private void Awake()
        {
            //Create statemachine
            PlayerStateFactory stateFactory = new PlayerStateFactory(this);
            stateMachine = new PlayerStateMachine(this, stateFactory);

            //Get components
            _input = GetComponent<PlayerInputs>();
            _stats = GetComponent<PlayerStats>();
            _controller = GetComponent<CharacterController>();
            _animator = GetComponent<Animator>();
            _mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
            _weaponManager = GetComponent<WeaponManager>();
            _attacker = GetComponent<Attacker>();

            AssignAnimationIDs();

            //Set default state
            //stateMachine.DebugStatesTransition(true);
            stateMachine.SetDefaultState("MoveState");
            stateMachine.OnEnter();
        }

        void Update()
        {
            stateMachine.OnUpdate();

            if (Stats.CurrentHealth <= 0)
                Animator.Play("Death");

            if(WeaponManager.CurrentWeapon != null)
                Animator.SetInteger(AnimID["WeaponType"], (int)WeaponManager.CurrentWeapon.Type);
            else
                Animator.SetInteger(AnimID["WeaponType"], 0);

            CheckInteractableObject();

            HandleChangeWeapon(); 
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

        public void OnDamage(DamageMessage message)
        {
            DamageMessageQueue.Enqueue(message);
        }

        public void CheckInteractableObject()
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, InteractRadius);
            for (int i = 0; i < colliders.Length; i++) 
            {
                Interactable interactableObjects = colliders[i].GetComponent<Interactable>();
                if (interactableObjects != null)
                {
                    //TODO: Show interact text

                    if (Input.interact)
                    {
                        interactableObjects.Interact(this);
                    }
                }
            }
        }

        public void HandleChangeWeapon()
        {
            if (Input.changeWeapon)
                WeaponManager.ChangeWeapon();
        }
    }

}