using PlayerControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public EnemyDataSO EnemyData;

    public int MaxHealth;
    public int CurrentHealth;

    void Start()
    {
        MaxHealth = EnemyData.MaxHealth;
        CurrentHealth = MaxHealth;
    }

    public void TakeDamage(int value)
    {
        CurrentHealth -= value;
        if (CurrentHealth < 0)
            CurrentHealth = 0;
    }
}
