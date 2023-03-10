using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WeaponSlotManager))]
public class WeaponManager : MonoBehaviour
{
    public WeaponSlotManager WeaponSlotManager;
    public WeaponItem Weapon;
    public BlockCollider BlockCollider;


    private void Awake()
    {
        WeaponSlotManager = GetComponent<WeaponSlotManager>();
        BlockCollider = GetComponentInChildren<BlockCollider>();
    }

    private void Start()
    {
        WeaponSlotManager.LoadWeaponOnSlot(Weapon);
    }

    public void OpenBlockCollider()
    {
        BlockCollider.SetDamageAbsortion(Weapon);
        BlockCollider.EnableBlockingCollider();
    }

    public void CloseBlockCollider()
    {
        BlockCollider.DisableBlockingCollider();
    }
}
