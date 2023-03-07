using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

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
            //设置目标速度
            float targetSpeed = 0.0f;
            if (manager.Input.move != Vector2.zero)
            {
                if (manager.Input.isWalking)
                    targetSpeed = manager.PlayerData.WalkSpeed;
                else if (manager.Input.isRunning)
                    targetSpeed = manager.PlayerData.RunSpeed;
                else
                    targetSpeed = manager.PlayerData.JoggingSpeed;
            }

            //速度线性插值变换
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

            //设置运动方向与transform前方
            Vector3 inputDirection = new Vector3(manager.Input.move.x, 0.0f, manager.Input.move.y);
            Vector3 speed;
            if(manager.Input.move != Vector2.zero)
            {
                if (manager.Input.isTargeting)
                {
                    Vector3 rotationDirection;
                    rotationDirection = manager.MainCamera.transform.forward;
                    rotationDirection.y = 0;
                    rotationDirection.Normalize();
                    Quaternion tr = Quaternion.LookRotation(rotationDirection);
                    Quaternion targetRotation = Quaternion.Slerp(manager.transform.rotation, tr, 5.0f * Time.deltaTime);
                    manager.transform.rotation = targetRotation;
                }
                else
                {
                    //基于镜头角度对运动方向进行修正, 保证在镜头空间中运动方向与镜头方向一致
                    targetRotation = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg + manager.MainCamera.transform.eulerAngles.y;
                    float rotation = Mathf.SmoothDampAngle(manager.transform.eulerAngles.y, targetRotation, ref rotateVelocity, manager.PlayerData.RotateSmoothTime);
                    manager.transform.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);
                }
            }

            if (manager.Input.isTargeting)
            {
                targetDirection = inputDirection.normalized;
                speed = targetDirection * targetSpeed;
                manager.Animator.SetFloat(manager.AnimID["VelocityX"], speed.x);
                manager.Animator.SetFloat(manager.AnimID["VelocityY"], speed.z);
            }
            else
            {
                targetDirection = (Quaternion.Euler(0.0f, targetRotation, 0.0f) * Vector3.forward).normalized;
                speed = targetDirection * targetSpeed;
                manager.Animator.SetFloat(manager.AnimID["VelocityX"], 0.0f);
                manager.Animator.SetFloat(manager.AnimID["VelocityY"], speed.magnitude);
            }

            //使用动画运动速度进行移动
            manager.Controller.Move(manager.Animator.velocity * Time.deltaTime);
        }
    }
}