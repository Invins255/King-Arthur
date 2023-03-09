using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    private Animator animator;
    private string lastAttackClip;
    private int comboCount = 0;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void HandleLightAttack(WeaponItem weapon)
    {
        //Check combo
        if (comboCount >= weapon.LightComboClips.Length)
            comboCount = 0;

        if (lastAttackClip == weapon.LightComboClips[comboCount])
            comboCount = (comboCount + 1) % weapon.LightComboClips.Length;
        else
            comboCount = 0;
        lastAttackClip = weapon.LightComboClips[comboCount];

        //Play attack animation (Maybe we should use animator.Play ?)
        animator.SetTrigger("LightAttack");

        //Set damage message
        DamageMessage message = new DamageMessage();
        message.Message = $"{gameObject.name}'s light attack";
        message.Attacker = gameObject;
        message.Weapon = weapon;
        GetComponent<WeaponSlotManager>().SetRightWeaponDamageMessage(message);
    }

    public void HandleHeavyAttack(WeaponItem weapon)
    {
        //Check combo
        if (comboCount >= weapon.HeavyComboClips.Length)
            comboCount = 0;

        if (lastAttackClip == weapon.HeavyComboClips[comboCount])
            comboCount = (comboCount + 1) % weapon.HeavyComboClips.Length;
        else
            comboCount = 0;
        lastAttackClip = weapon.HeavyComboClips[comboCount];

        //Play attack animation
        animator.SetTrigger("HeavyAttack");

        //Set damage message
        DamageMessage message = new DamageMessage();
        message.Message = $"{gameObject.name}'s heavy attack";
        message.Attacker = gameObject;
        message.Weapon = weapon;
        GetComponent<WeaponSlotManager>().SetRightWeaponDamageMessage(message);
    }
}
