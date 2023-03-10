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

    public WeaponType Type = WeaponType.None;

    [Header("Attack Animation")]
    public string[] LightComboClips;
    public string[] HeavyComboClips;

    [Header("Damage")]
    public int Damage;

    [Header("Absorption")]
    [Range(0.0f, 1.0f)]
    public float DamageAbsorption;
}
