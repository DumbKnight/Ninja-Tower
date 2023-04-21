using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static GameObject PlayerObject;

    //Components
    [Header("Components")]

    public GrabbingHook GrabbingHook;

    [Space]

    public Rigidbody2D Rigidbody2D;

    [Space]

    public DeathMenu DeathMenu;
    //Components

    void Awake()
    {
        PlayerObject = this.gameObject;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && GrabbingHook.JointEnabled == false && Time.time >= GrabbingHook.NextHookTimer)
        {
            GrabbingHook.CreateHook();
        }
    }

    public void GetDamage()
    {
        DeathMenu.Death();
    }
}
