using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerControl
{
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerInputs : MonoBehaviour
    {
        [Header("Input values")]
        public Vector2 move;
        public bool isRunning = false;
        public bool isWalking = false;
        public Vector2 look;
        public bool lightAttack;
        public bool heavyAttack;
        public bool dodge;

        public void OnMove(InputAction.CallbackContext callback)
        {
            move = callback.ReadValue<Vector2>();
        }

        public void OnRun(InputAction.CallbackContext callback)
        {
            isRunning = callback.ReadValueAsButton();
        }

        public void OnWalk(InputAction.CallbackContext callback)
        {
            isWalking = !isWalking;
        }

        public void OnLook(InputAction.CallbackContext callback)
        {
            look = callback.ReadValue<Vector2>();
        }

        public void OnLightAttack(InputAction.CallbackContext callback)
        {
            if (callback.started || callback.canceled)
            {
                lightAttack = callback.ReadValueAsButton();
            }
        }

        public void OnHeavyAttack(InputAction.CallbackContext callback)
        {
            if (callback.started || callback.canceled)
            {
                heavyAttack = callback.ReadValueAsButton();
            }
        }

        public void OnDodge(InputAction.CallbackContext callback)
        {
            if (callback.started || callback.canceled)
            {
                dodge = callback.ReadValueAsButton();
            }
        }
    }

}