using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    //Attack Rate
    [Header("Attack Rate")]

    public float AttackRate;

    private float NextAttackTimer;
    //Attack Rate

    void Awake()
    {
        NextAttackTimer = Time.time;
    }

    void Update()
    {
        if (Time.time >= NextAttackTimer)
        {
            Attack();
        }
    }

    void Attack()
    {
        GetComponent<Enemy>().Animator.SetTrigger("Attack");

        NextAttackTimer += AttackRate;
    }
}
