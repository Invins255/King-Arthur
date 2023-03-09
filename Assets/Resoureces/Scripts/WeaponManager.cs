using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WeaponSlotManager))]
public class WeaponManager : MonoBehaviour
{
    public WeaponSlotManager WeaponSlotManager;

    public WeaponItem LeftWeapon;
    public WeaponItem RightWeapon;

    private void Awake()
    {
        WeaponSlotManager = GetComponent<WeaponSlotManager>();
    }

    private void Start()
    {
        WeaponSlotManager.LoadWeaponOnSlot(LeftWeapon, true);
        WeaponSlotManager.LoadWeaponOnSlot(RightWeapon, false);
    }
}
