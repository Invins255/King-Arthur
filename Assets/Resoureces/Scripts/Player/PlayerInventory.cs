using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<WeaponItem> WeaponsInventory;
    private WeaponManager weaponManager;

    private void Awake()
    {
        weaponManager = GetComponent<WeaponManager>();
    }

    public void AddWeapon(WeaponItem weapon)
    {
        WeaponsInventory.Add(weapon);
        for(int i = 0; i < weaponManager.Weapons.Length; i++)
        {
            if(weaponManager.Weapons[i] == null)
            {
                weaponManager.Weapons[i] = weapon;
                break;
            }
        }
    }
}
