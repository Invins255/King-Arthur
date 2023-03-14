using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    private GameObject mainCamera;
    private Animator animator;
    private string lastAttackClip;
    private int comboCount = 0;

    public float DetectionRadius = 5.0f;
    public float DetectionAngle = 60.0f;
    public List<EnemyController> AvilableTargets = new List<EnemyController>();
    public EnemyController CurrentTarget;

    private void Awake()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        animator = GetComponent<Animator>();
    }

    public void HandleLightAttack(WeaponItem weapon)
    {
        GetClosestTarget();
        RotateToTarget();

        //Check combo
        if (comboCount >= weapon.LightComboClips.Length)
            comboCount = 0;

        if (lastAttackClip == weapon.LightComboClips[comboCount])
            comboCount = (comboCount + 1) % weapon.LightComboClips.Length;
        else
            comboCount = 0;
        lastAttackClip = weapon.LightComboClips[comboCount];

        //Play attack animation (Maybe we should use animator.Play ?)
        animator.SetTrigger("LightAttack");

        //Set damage message
        DamageMessage message = new DamageMessage();
        message.Message = $"{gameObject.name}'s light attack";
        message.Attacker = gameObject;
        message.Weapon = weapon;
        GetComponent<WeaponSlotManager>().SetWeaponDamageMessage(message);

        ClearTargets();
    }

    public void HandleHeavyAttack(WeaponItem weapon)
    {
        GetClosestTarget();
        RotateToTarget();

        //Check combo
        if (comboCount >= weapon.HeavyComboClips.Length)
            comboCount = 0;

        if (lastAttackClip == weapon.HeavyComboClips[comboCount])
            comboCount = (comboCount + 1) % weapon.HeavyComboClips.Length;
        else
            comboCount = 0;
        lastAttackClip = weapon.HeavyComboClips[comboCount];

        //Play attack animation
        animator.SetTrigger("HeavyAttack");

        //Set damage message
        DamageMessage message = new DamageMessage();
        message.Message = $"{gameObject.name}'s heavy attack";
        message.Attacker = gameObject;
        message.Weapon = weapon;
        GetComponent<WeaponSlotManager>().SetWeaponDamageMessage(message);

        ClearTargets();
    }

    public void GetTargetInRange()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, DetectionRadius);

        for (int i = 0; i < colliders.Length; i++)
        {
            EnemyController enemy = colliders[i].GetComponent<EnemyController>();
            if (enemy != null)
            {
                Vector3 lockTargetDirection = enemy.transform.position - transform.position;
                float viewableAngle = Vector3.Angle(lockTargetDirection, mainCamera.transform.forward);

                if (viewableAngle >= -DetectionAngle && viewableAngle <= DetectionAngle)
                {
                    AvilableTargets.Add(enemy);
                }
            }
        }
    }

    public void GetClosestTarget()
    {
        GetTargetInRange();

        float minDistance = Mathf.Infinity;
        for (int i = 0; i < AvilableTargets.Count; i++)
        {
            float distance = Vector3.Distance(transform.position, AvilableTargets[i].transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                CurrentTarget = AvilableTargets[i];
            }
        }
    }

    public void ClearTargets()
    {
        AvilableTargets.Clear();
        CurrentTarget = null;
    }

    private void RotateToTarget()
    {
        if (CurrentTarget != null)
        {
            GameObject target = CurrentTarget.gameObject;
            Vector3 targetDirection = (target.transform.position - transform.position);
            targetDirection.y = 0.0f;
            targetDirection = targetDirection.normalized;
            Quaternion quaternion = Quaternion.LookRotation(targetDirection, Vector3.up);
            transform.rotation = quaternion;
        }
    }

    private void OnDrawGizmosSelected()
    {
        float minAngle = -DetectionAngle;
        float maxAngle = DetectionAngle;
        float radius = DetectionRadius;
        Gizmos.color = Color.yellow;
        for (float i = minAngle; i < maxAngle; i += (maxAngle - minAngle) / 10)
        {
            Gizmos.DrawLine(transform.position, transform.position + Quaternion.Euler(0, i, 0) * transform.forward * radius);
        }
    }
}
