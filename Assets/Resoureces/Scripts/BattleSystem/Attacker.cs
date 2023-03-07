using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    private Animator animator;
    private string lastAttackClip;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void HandleLightAttack(WeaponItem weapon)
    {
        //TODO: Play attack animation
        //TODO: Check combo
    }

    public void HandleHeavyAttack(WeaponItem weapon)
    {

    }
}
