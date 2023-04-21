using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //Layers
    [Header("Layers")]

    public LayerMask LayerMask;
    //Layers

    //Save
    [Header("Save")]

    public Save SaveItem;
    //Save

    void OnTriggerEnter2D(Collider2D Player)
    {
        if (LayerMask == (LayerMask | (1 << Player.gameObject.layer)))
        {
            SaveItem.Coins += 1;

            Destroy(gameObject);
        }
    }
}
