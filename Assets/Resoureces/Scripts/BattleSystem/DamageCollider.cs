using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    public Collider Collider;
    public DamageMessage Message;

    private void Awake()
    {
        Collider = GetComponent<Collider>();
        Collider.gameObject.SetActive(true);
        Collider.enabled = false;
        Collider.isTrigger = true;

        //TEMP
        Message = new DamageMessage();
        Message.Message = "Default message";
    }

    public void EnableDamageCollider()
    {
        Collider.enabled = true;
    }

    public void DisableDamageCollider()
    {
        Collider.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Damageable target))
        {
            target.OnDamageEvent?.Invoke(Message);
        }
    }
}
