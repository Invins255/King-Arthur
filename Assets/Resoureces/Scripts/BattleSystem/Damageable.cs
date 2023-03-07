using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


/// <summary>
/// 攻击者相关信息，通过受击回调事件时进行传递，由受击者接收
/// </summary>
public class DamageMessage
{
    public string Message;
    public GameObject Attacker;
    public WeaponItem Weapon;
}

/// <summary>
/// 受击事件
/// </summary>
[Serializable]
public class DamageEvent : UnityEvent<DamageMessage> { }

/// <summary>
/// 可受击对象
/// </summary>
public class Damageable : MonoBehaviour
{
    public DamageEvent OnDamageEvent;
}
