using PlayerControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : Interactable
{
    public WeaponItem Weapon;

    public override void Interact(PlayerController playerController)
    {
        base.Interact(playerController);

        PickUpItem(playerController);
    }

    private void PickUpItem(PlayerController playerController)
    {
        PlayerInventory inventory = playerController.GetComponent<PlayerInventory>();
        inventory.AddWeapon(Weapon);
        Destroy(gameObject);
    }
}
