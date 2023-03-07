using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Items/Weapon Item")]
public class WeaponItem : Item
{
    public GameObject ModelPrefab;
    public bool IsUnarmed;

    [Header("Animation")]
    public string[] LightComboClips;
    public string[] HeavyComboClips;

    [Header("Atrributes")]
    public int Damage;
}
