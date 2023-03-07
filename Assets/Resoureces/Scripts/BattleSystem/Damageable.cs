using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


/// <summary>
/// �����������Ϣ��ͨ���ܻ��ص��¼�ʱ���д��ݣ����ܻ��߽���
/// </summary>
public class DamageMessage
{
    public string Message;
    public GameObject Attacker;
    public WeaponItem Weapon;
}

/// <summary>
/// �ܻ��¼�
/// </summary>
[Serializable]
public class DamageEvent : UnityEvent<DamageMessage> { }

/// <summary>
/// ���ܻ�����
/// </summary>
public class Damageable : MonoBehaviour
{
    public DamageEvent OnDamageEvent;
}
