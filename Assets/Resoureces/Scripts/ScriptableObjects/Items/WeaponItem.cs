using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    None = 0,
    OnehandedSword = 1,
    TwohandedSword = 2
}


[CreateAssetMenu(menuName = "ScriptableObject/Items/Weapon Item")]
public class WeaponItem : Item
{
    public GameObject ModelPrefab;
    public bool IsUnarmed;

    public WeaponType Type = WeaponType.None;

    [Header("Attack Animation")]
    public string[] LightComboClips;
    public string[] HeavyComboClips;

    [Header("Atrributes")]
    public int Damage;
}
