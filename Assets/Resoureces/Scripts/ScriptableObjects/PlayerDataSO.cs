using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerControl
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObject/PlayerData", order = 0)]
    public class PlayerDataSO : ScriptableObject
    {
        [Header("Locomotion")]
        public float WalkSpeed;
        public float JoggingSpeed;
        public float RunSpeed;
        public float SpeedChangeRate;
        public float RotateSmoothTime;

        [Header("Health")]
        public int MaxHealth;
    }
}