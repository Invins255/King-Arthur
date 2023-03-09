using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObject/Enemy/EnemyData", order = 1)]
public class EnemyDataSO : ScriptableObject
{
    [Header("Locomotion")]
    public float WalkThreshold;
    public float JoggingThreshold;
    public float RunThreshold;
    public float RotationSpeed;

    [Header("Health")]
    public int MaxHealth;

    [Header("AI Settings")]
    public float DetectionRadius;
    public float MinDetectionAngle;
    public float MaxDetectionAngle;
    public float StopingDistance;

}
