using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [Header("Animator parameter IDs")]
    public string[] AnimParams;
    //Animation hash IDs
    public Dictionary<string, int> AnimID = new Dictionary<string, int>();

    public Animator Animator { get { return _animator; } }
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();

        AssignAnimationIDs();
    }

    void Update()
    {
        
    }

    public void OnDamage(DamageMessage message)
    {
        HandleDamage(message);
    }

    private void HandleDamage(DamageMessage message)
    {
        Debug.Log($"{gameObject.name} was attacked. Message: {message.Message}");
        Animator.SetTrigger(AnimID["Hit"]);

        //计算Attacker到自身的水平方向
        Vector3 dir = -transform.InverseTransformPoint(message.Attacker.transform.position);
        dir.y = 0.0f;
        dir = dir.normalized;

        Animator.SetFloat("HitX", dir.x);
        Animator.SetFloat("HitY", dir.z);
    }

    private void AssignAnimationIDs()
    {
        foreach (string name in AnimParams)
        {
            AnimID.Add(name, Animator.StringToHash(name));
        }
    }
}
