using PlayerControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerControl
{
    public class PlayerStats : MonoBehaviour
    {
        public PlayerDataSO PlayerData;

        public int MaxHealth;
        public int CurrentHealth;

        void Start()
        {
            MaxHealth = PlayerData.MaxHealth;
            CurrentHealth = MaxHealth;
        }

        public void TakeDamage(int value)
        {
            CurrentHealth -= value;
            if (CurrentHealth < 0)
                CurrentHealth = 0;
        }
    }
}
