using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyAttackAction", menuName = "ScriptableObject/Enemy/Enemy Actions/Attack Action")]
public class EnemyAttackAction : EnemyAction
{
    public float RecoverTime = 2;
    public int Weight = 3;

    public float MinAttackDistance = 0.0f;
    public float MaxAttackDistance = 3.0f;
    public float MinAttackAngle = -45.0f;
    public float MaxAttackAngle =  45.0f;   
}
