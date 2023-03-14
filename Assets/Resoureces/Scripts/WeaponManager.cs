using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WeaponSlotManager))]
public class WeaponManager : MonoBehaviour
{
    public WeaponSlotManager WeaponSlotManager;
    public WeaponItem CurrentWeapon;
    public BlockCollider BlockCollider;

    public WeaponItem[] Weapons = new WeaponItem[3];
    public int CurrentWeaponIndex = 0;

    public WeaponItem UnarmedWeapon;

    private void Awake()
    {
        WeaponSlotManager = GetComponent<WeaponSlotManager>();
        BlockCollider = GetComponentInChildren<BlockCollider>();
    }

    private void Start()
    {
        WeaponSlotManager.LoadWeaponOnSlot(CurrentWeapon);
    }

    public void OpenBlockCollider()
    {
        BlockCollider.SetDamageAbsortion(CurrentWeapon);
        BlockCollider.EnableBlockingCollider();
    }

    public void CloseBlockCollider()
    {
        BlockCollider.DisableBlockingCollider();
    }

    public void ChangeWeapon()
    {
        CurrentWeaponIndex++;
        if(CurrentWeaponIndex == Weapons.Length)
            CurrentWeaponIndex = 0;

        if(Weapons[CurrentWeaponIndex] != null)
        {
            CurrentWeapon = Weapons[CurrentWeaponIndex];
        }
        else
        {
            CurrentWeapon = UnarmedWeapon;
        }

        WeaponSlotManager.LoadWeaponOnSlot(CurrentWeapon);
        Debug.Log($"Current weapon {CurrentWeapon.ItemName}");
    }
}
