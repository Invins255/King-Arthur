using PlayerControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public string InteractableText;

    public virtual void Interact(PlayerController playerController)
    {
        Debug.Log($"Player interact {gameObject.name}");
    }
}
