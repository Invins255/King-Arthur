using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacker : MonoBehaviour
{
    private EnemyController controller;
    private Animator animator;

    public EnemyAttackAction[] AttackActions;
    public EnemyAttackAction CurrentAttackAction;

    private void Awake()
    {
        controller = GetComponent<EnemyController>();
        animator = GetComponent<Animator>();
    }

    public void GetNewAttack()
    {
        Vector3 targetDirection = controller.Locomotion.CurrentTarget.transform.position - transform.position;
        float viewableAngle = Vector3.Angle(targetDirection, targetDirection);

        List<EnemyAttackAction> actions = new List<EnemyAttackAction>();
        int weightSum = 0;

        for (int i = 0; i < AttackActions.Length; i++)
        {
            EnemyAttackAction action = AttackActions[i];

            if (controller.Locomotion.DistanceToTarget <= action.MaxAttackDistance &&
                controller.Locomotion.DistanceToTarget >= action.MinAttackDistance)
            {
                if (viewableAngle <= action.MaxAttackDistance &&
                   viewableAngle >= action.MinAttackDistance)
                {
                    weightSum += action.Weight;
                    actions.Add(action);
                }
            }
        }

        int randomValue = UnityEngine.Random.Range(0, weightSum);
        int tempWeightSum = 0;

        for (int i = 0; i < actions.Count; i++)
        {
            if (CurrentAttackAction != null)
                return;

            tempWeightSum += actions[i].Weight;
            if (tempWeightSum > randomValue)
                CurrentAttackAction = actions[i];
        }
    }
}
