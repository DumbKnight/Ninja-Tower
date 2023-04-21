using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookRaycaster : MonoBehaviour
{
    //Layers
    [Header("Layers")]

    public LayerMask LayerMask;
    //Layers

    public RaycastHit2D[] Raycast(Vector2 Origin, Vector2 Target, float Distance)
    {
        return Physics2D.RaycastAll(Origin, Target - Origin, Distance, LayerMask);
    }
}
