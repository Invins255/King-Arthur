using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCollider : MonoBehaviour
{
    public Collider Collider;
    public float BlockingDamageAbsorption;

    private void Awake()
    {
        Collider = GetComponent<Collider>();
        Collider.gameObject.SetActive(true);
        Collider.enabled = false;
    }

    public void SetDamageAbsortion(WeaponItem weapon)
    {
        if (weapon != null) 
        {
            BlockingDamageAbsorption = weapon.DamageAbsorption;
        }
    }

    public void EnableBlockingCollider()
    {
        Collider.enabled = true;
    }

    public void DisableBlockingCollider()
    {
        Collider.enabled = false;
    }
}
