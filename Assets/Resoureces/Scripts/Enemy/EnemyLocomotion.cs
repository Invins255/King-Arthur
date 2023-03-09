using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyLocomotion : MonoBehaviour
{
    private EnemyController controller;
    
    public LayerMask DetectionLayer;
    public GameObject CurrentTarget;
    public float DistanceToTarget;

    private void Awake()
    {
        controller = GetComponent<EnemyController>();
        controller.NavMeshAgent.stoppingDistance = controller.EnemyData.StopingDistance;
    }

    private void FixedUpdate()
    {
        if (CurrentTarget != null)
            DistanceToTarget = Vector3.Distance(CurrentTarget.transform.position, transform.position);
    }

    public void Detection()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, controller.EnemyData.DetectionRadius, DetectionLayer);

        for(int i=0; i < colliders.Length; i++)
        {
            GameObject target = colliders[i].gameObject;
            if(target.tag == "Player")
            {
                Vector3 targetDirection = target.transform.position - transform.position;
                float viewableAngle = Vector3.Angle(targetDirection, transform.forward);

                if(viewableAngle > controller.EnemyData.MinDetectionAngle && viewableAngle < controller.EnemyData.MaxDetectionAngle)
                {
                    CurrentTarget = target;
                }
            }
        }
    }

    public void MoveToTarget()
    {
        if(controller.IsPerformingAction)
        {
            controller.NavMeshAgent.enabled = false;
            controller.Animator.SetFloat("VelocityY", 0.0f);
        }
        else
        {
            float target = 0.0f;
            if(DistanceToTarget > controller.EnemyData.StopingDistance)
            {
                target = controller.EnemyData.WalkThreshold;
            }
            else
            {
                target = 0.0f;
            }
            controller.Animator.SetFloat("VelocityY", target, 0.5f, Time.deltaTime);
        }

        RotateTowardsTarget();
    }

    private void RotateTowardsTarget()
    {
        Vector3 direction = CurrentTarget.transform.position - transform.position;
        direction.y = 0;
        direction.Normalize();
        if (direction == Vector3.zero)
            direction = transform.forward;
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        if (!controller.IsPerformingAction)
        { 
            //Rotate with pathfinding 
            controller.NavMeshAgent.enabled = true;
            controller.NavMeshAgent.SetDestination(CurrentTarget.transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, controller.EnemyData.RotationSpeed * Time.deltaTime);
        }

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, controller.EnemyData.RotationSpeed * Time.deltaTime);
    }

    public void StopMove()
    {
        controller.NavMeshAgent.enabled = false;
        controller.Animator.SetFloat("VelocityY", 0.0f);
    }

    private void OnDrawGizmos()
    {
        if(controller != null)
        { 
            float minAngle = controller.EnemyData.MinDetectionAngle;
            float maxAngle = controller.EnemyData.MaxDetectionAngle;
            float radius = controller.EnemyData.DetectionRadius;
            Gizmos.color = CurrentTarget == null ? Color.yellow : Color.red;
            for (float i = minAngle; i < maxAngle; i += (maxAngle - minAngle) / 10)
            {
                Gizmos.DrawLine(transform.position, transform.position + Quaternion.Euler(0, i, 0) * transform.forward * radius);
            }
        }
    }
}
