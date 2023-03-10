using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public EnemyDataSO EnemyData;

    public bool IsPerformingAction;
    public EnemyAttackAction[] AttackActions;
    public EnemyAttackAction CurrentAttackAction;

    private float currentRecoverTime;

    public EnemyStats Stats { get { return _stats; } }
    private EnemyStats _stats;
    public EnemyLocomotion Locomotion { get { return _locomotion; } }
    private EnemyLocomotion _locomotion;
    public WeaponManager WeaponManager { get { return _weaponManager; } }
    private WeaponManager _weaponManager;
    public Animator Animator { get { return _animator; } }
    private Animator _animator;
    public Rigidbody Rigidbody { get { return _rigidbody; } }
    private Rigidbody _rigidbody;
    public NavMeshAgent NavMeshAgent { get { return _navMeshAgent; } }
    private NavMeshAgent _navMeshAgent;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _stats = GetComponent<EnemyStats>();
        _locomotion = GetComponent<EnemyLocomotion>();
        _weaponManager = GetComponent<WeaponManager>();
        _rigidbody = GetComponent<Rigidbody>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        NavMeshAgent.enabled = false;
        Rigidbody.isKinematic = false;

        if (WeaponManager.Weapon != null)
            Animator.SetInteger("WeaponType", (int)WeaponManager.Weapon.Type);
        else
            Animator.SetInteger("WeaponType", 0);
    }

    void Update()
    {
        if (Stats.CurrentHealth == 0)
            Death();

        HandleRecoverTimer();
    }

    private void FixedUpdate()
    {
        if (Stats.CurrentHealth > 0)
            HandleCurrentAction();
    }

    private void OnAnimatorMove()
    {
        NavMeshAgent.velocity = Animator.velocity;

        Rigidbody.drag = 0;
        Rigidbody.velocity = Animator.velocity;
    }

    private void HandleCurrentAction()
    {
        if (Locomotion.CurrentTarget == null)
            Locomotion.Detection();
        else
        {
            if (Locomotion.DistanceToTarget > EnemyData.StopingDistance)
                Locomotion.MoveToTarget();
            else if (Locomotion.DistanceToTarget <= EnemyData.StopingDistance)
            {
                Locomotion.StopMove();
                AttackTarget();
            }
        }
    }

    #region Attacks
    private void GetNewAttack()
    {
        Vector3 targetDirection = Locomotion.CurrentTarget.transform.position - transform.position;
        float viewableAngle = Vector3.Angle(targetDirection, targetDirection);

        List<EnemyAttackAction> actions = new List<EnemyAttackAction>();
        int weightSum = 0;

        for(int i = 0; i < AttackActions.Length; i++)
        {
            EnemyAttackAction action = AttackActions[i];
            
            if( Locomotion.DistanceToTarget <= action.MaxAttackDistance &&
                Locomotion.DistanceToTarget >= action.MinAttackDistance )
            {
                if(viewableAngle <= action.MaxAttackDistance &&
                   viewableAngle >= action.MinAttackDistance)
                {
                    weightSum += action.Weight;
                    actions.Add(action);
                }
            }
        }

        int randomValue = UnityEngine.Random.Range(0, weightSum);
        int tempWeightSum = 0;

        for(int i = 0; i < actions.Count; i++)
        {
            if (CurrentAttackAction != null)
                return;

            tempWeightSum += actions[i].Weight;
            if (tempWeightSum > randomValue)
                CurrentAttackAction = actions[i];
        }
    }

    private void AttackTarget()
    {
        if (IsPerformingAction)
            return;

        if (CurrentAttackAction == null)
            GetNewAttack();

        IsPerformingAction = true;
        currentRecoverTime = CurrentAttackAction.RecoverTime;

        DamageMessage message = new DamageMessage();
        message.Message = $"{gameObject.name}'s attack";
        message.Attacker = gameObject;
        message.Weapon = WeaponManager.Weapon;
        GetComponent<WeaponSlotManager>().SetWeaponDamageMessage(message);

        Animator.Play(CurrentAttackAction.ActionAnimation);
        CurrentAttackAction = null;
    }

    private void HandleRecoverTimer()
    {
        if(currentRecoverTime > 0)
            currentRecoverTime -= Time.deltaTime;
        if(IsPerformingAction)
        {
            if(currentRecoverTime <= 0)
                IsPerformingAction = false;
        }
    }
    #endregion

    #region Damage
    public void OnDamage(DamageMessage message)
    {
        HandleDamage(message);
    }

    private void HandleDamage(DamageMessage message)
    {
        Debug.Log($"{gameObject.name} was attacked. Message: {message.Message}");


        //计算Attacker到自身的水平方向
        Vector3 dir = -transform.InverseTransformPoint(message.Attacker.transform.position);
        dir.y = 0.0f;
        dir = dir.normalized;

        Animator.SetFloat("HitX", dir.x);
        Animator.SetFloat("HitY", dir.z);
        Animator.SetTrigger("Hit");

        Stats.TakeDamage(message.Weapon.Damage);
    }

    private void Death()
    {
        Animator.Play("Death");
        GetComponent<CapsuleCollider>().enabled = false;
    }
    #endregion
}
