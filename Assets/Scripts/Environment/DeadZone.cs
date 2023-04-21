using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
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

