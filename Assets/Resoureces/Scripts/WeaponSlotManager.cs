using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class WeaponSlotManager : MonoBehaviour
{
    private WeaponHolderSlot holdSlot;
    private DamageCollider weaponDamageCollider;

    private void Awake()
    {
        WeaponHolderSlot[] weaponHolderSlots = GetComponentsInChildren<WeaponHolderSlot>();
        foreach (WeaponHolderSlot weaponHolderSlot in weaponHolderSlots)
        {
            holdSlot = weaponHolderSlot;
        }
    }

    public void LoadWeaponOnSlot(WeaponItem weaponItem)
    {
        if(holdSlot != null)
        {
            holdSlot.LoadWeaponModel(weaponItem);
            if(holdSlot.CurrentWeaponModel!=null)
            {
                weaponDamageCollider = holdSlot.CurrentWeaponModel.GetComponentInChildren<DamageCollider>();
            }
        }
    }

    public void OpenWeaponDamageCollider()
    {
        if (weaponDamageCollider != null)
            weaponDamageCollider.EnableDamageCollider();
    }

    public void CloseWeaponDamageCollider()
    {
        if (weaponDamageCollider != null)
            weaponDamageCollider.DisableDamageCollider();
    }

    public void SetWeaponDamageMessage(DamageMessage message)
    {
        if (weaponDamageCollider != null)
            weaponDamageCollider.Message = message;
    }
}
