using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSlotManager : MonoBehaviour
{
    private WeaponHolderSlot leftHandSlot;
    private WeaponHolderSlot rightHandSlot;

    private DamageCollider leftDamageCollider;
    private DamageCollider rightDamageCollider;

    private void Awake()
    {
        WeaponHolderSlot[] weaponHolderSlots = GetComponentsInChildren<WeaponHolderSlot>();
        foreach (WeaponHolderSlot weaponHolderSlot in weaponHolderSlots)
        {
            if (weaponHolderSlot.IsLeftHandSlot)
                leftHandSlot = weaponHolderSlot;
            if(weaponHolderSlot.IsRightHandSlot)
                rightHandSlot = weaponHolderSlot;
        }
    }

    public void LoadWeaponOnSlot(WeaponItem weaponItem, bool isLeft)
    {
        if (isLeft)
        {
            if (leftHandSlot != null)
            { 
                leftHandSlot.LoadWeaponModel(weaponItem);     
                if(leftHandSlot.CurrentWeaponModel != null)
                {
                    leftDamageCollider = leftHandSlot.CurrentWeaponModel.GetComponentInChildren<DamageCollider>();
                }
            }
        }
        else
        {
            if(rightHandSlot != null)
            {
                rightHandSlot.LoadWeaponModel(weaponItem);
                if(rightHandSlot.CurrentWeaponModel != null)
                {
                    rightDamageCollider = rightHandSlot.CurrentWeaponModel.GetComponentInChildren<DamageCollider>();
                }
            }
        }
    }

    public void OpenLeftWeaponDamageCollider()
    {
        if(leftDamageCollider != null)
            leftDamageCollider.EnableDamageCollider();
    }

    public void CloseLeftWeaponDamageCollider()
    {
        if (leftDamageCollider != null)
            leftDamageCollider.DisableDamageCollider();
    }

    public void OpenRightWeaponDamageCollider()
    {
        if (rightDamageCollider != null)
            rightDamageCollider.EnableDamageCollider();
    }

    public void CloseRightWeaponDamageCollider()
    {
        if (rightDamageCollider != null)
            rightDamageCollider.DisableDamageCollider();
    }

    public void SetLeftWeaponDamageMessage(DamageMessage message)
    {
        if (leftDamageCollider != null)
            leftDamageCollider.Message = message;
    }

    public void SetRightWeaponDamageMessage(DamageMessage message)
    {
        if (rightDamageCollider != null)
            rightDamageCollider.Message = message;
    }
}
