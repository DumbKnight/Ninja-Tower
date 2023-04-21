using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour
{
    //

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
        Aim();

        if (Time.time >= NextAttackTimer)
        {
            Attack();
        }
    }

    void Aim()
    {
        Debug.DrawRay(transform.position, Player.PlayerObject.transform.position, Color.green);
    }

    void Attack()
    {
        GetComponent<Enemy>().Animator.SetTrigger("Attack");

        NextAttackTimer += AttackRate;
    }
}
