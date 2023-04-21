using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    //Scripts & Components
    [Header("Scripts & Components")]

    public Animator Animator;
    //Scripts & Components
    
    //Layers
    [Header("Layers")]

    public LayerMask LayerMask;
    //Layers
    
    void OnTriggerEnter2D(Collider2D Entity)
    {
        if (LayerMask == (LayerMask | (1 << Entity.gameObject.layer)))
        {
            Entity.GetComponent<Player>().GetDamage();
        }
    }
}
