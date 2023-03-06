using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace PlayerControl
{
    public class MoveState : IState<PlayerController>
    {
        float targetRotation;
        float rotateVelocity;
        Vector3 targetDirection;

        public MoveState(PlayerController manager) : base(manager)
        {
        }

        public override void OnAnimatorMove()
        {
            Move();
        }

        public override void OnEnter()
        {
            base.OnEnter();
        }

        public override void OnExit()
        {
            base.OnExit();
        }

        public override void OnUpdate()
        {

        }

        private void Move()
        {
            float targetSpeed;
            if (manager.Input.isWalking)
                targetSpeed = manager.PlayerData.WalkSpeed;
            else if (manager.Input.isRunning)
                targetSpeed = manager.PlayerData.RunSpeed;
            else
                targetSpeed = manager.PlayerData.JoggingSpeed;

            if (manager.Input.move == Vector2.zero)
            {
                targetSpeed = 0.0f;
            }

            const float speedOffset = 0.1f;
            if (manager.CurrentHorizontalSpeed < targetSpeed - speedOffset ||
            manager.CurrentHorizontalSpeed > targetSpeed + speedOffset)
            {
                manager.CurrentHorizontalSpeed = Mathf.Lerp(manager.CurrentHorizontalSpeed, targetSpeed, Time.deltaTime * manager.PlayerData.SpeedChangeRate);
            }
            else
            {
                manager.CurrentHorizontalSpeed = targetSpeed;
            }

            Vector3 inputDirection = new Vector3(manager.Input.move.x, 0.0f, manager.Input.move.y);
            if (manager.Input.move != Vector2.zero)
            {
                //基于镜头角度对运动方向进行修正
                targetRotation = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg + manager.MainCamera.transform.eulerAngles.y;
                float rotation = Mathf.SmoothDampAngle(manager.transform.eulerAngles.y, targetRotation, ref rotateVelocity, manager.PlayerData.RotateSmoothTime);

                manager.transform.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);
            }

            targetDirection = (Quaternion.Euler(0.0f, targetRotation, 0.0f) * Vector3.forward).normalized;


            Vector3 speed = targetDirection * manager.CurrentHorizontalSpeed;
            //manager.Animator.SetFloat(manager.AnimID["VelocityX"], speed.x);
            //manager.Animator.SetFloat(manager.AnimID["VelocityY"], speed.z);
            //使用动画运动速度进行移动
            manager.Animator.SetFloat(manager.AnimID["HorizontalSpeed"], speed.magnitude);
            manager.Controller.Move(manager.Animator.velocity * Time.deltaTime);
        }
    }
}