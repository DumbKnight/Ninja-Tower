using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbingHook : MonoBehaviour
{
    #region Components
    [Header("Components")]

    public Camera Camera;

    [Space]

    public Player Player;

    [Space]

    public HookRaycaster HookRaycaster;

    [Space]

    public HookRender HookRender;

    [Space]

    public DistanceJoint2D DistanceJoint2D;
    #endregion
    
    #region HookParameters
    [Header("Hook Parameters")]

    public float MaxLength;
    public float MinDistance;

    [Space]

    public float Speed;
    public float Impulse;
    #endregion

    #region Conditions
    [Header("Conditions")]

    public float TimeStep;

    [HideInInspector]
    public float NextHookTimer;

    public bool JointEnabled => DistanceJoint2D.enabled;
    #endregion

    //Layers
    [Header("Layers")]

    public LayerMask LayerMask;
    //Layers
    
    //Other
    private RaycastHit2D[] Hits;

    private int HitIndex;

    public Collider2D PlatformInside;
    //Other
    
    void FixedUpdate()
    {
        if (DistanceJoint2D.enabled)
        {
            HookRender.RenderLine(transform.position, Hits[HitIndex].collider.gameObject.transform.position);

            Climb();
        }
    }
    
    public void CreateHook()
    {
        HitIndex = -1;

        Vector2 Target = Camera.ScreenToWorldPoint(Input.mousePosition);

        Hits = HookRaycaster.Raycast(transform.position, Target, MaxLength);

        if (Physics.Raycast(Camera.ScreenToWorldPoint(Input.mousePosition), transform.forward, out RaycastHit PlatformCollider, Mathf.Infinity, LayerMask))
        {
            bool flag = false;

            if (PlatformInside == null) //Внутри ничего нет
            {
                flag = true;
            }
            else
            {
                if (PlatformInside.gameObject != PlatformCollider.transform.parent.gameObject) //Цель - не объект внутри
                {
                    flag = true;
                }
            }

            if (flag == true)
            {
                for (int i = 0; i < Hits.Length; i++)
                {
                    if (PlatformCollider.transform.parent.gameObject == Hits[i].collider.gameObject)
                    {
                        HitIndex = i;

                        break;
                    }
                }

                if (HitIndex != -1)
                {
                    DistanceJoint2D.enabled = true;

                    DistanceJoint2D.connectedAnchor = Hits[HitIndex].collider.gameObject.transform.position;

                    DistanceJoint2D.distance = Vector2.Distance(transform.position, Hits[HitIndex].collider.gameObject.transform.position);

                    HookRender.RenderLine(transform.position, Hits[HitIndex].collider.gameObject.transform.position);
                }
            }
        }
    }
    
    public void DisableHook()
    {
        Vector2 PlayerPosition = Player.transform.position;

        Vector2 AngleImpulse = (DistanceJoint2D.connectedAnchor - PlayerPosition).normalized;

        DistanceJoint2D.enabled = false;

        Player.GetComponent<Rigidbody2D>().velocity += AngleImpulse * Impulse;

        NextHookTimer = Time.time + TimeStep;

        HookRender.Disable();
    }
    
    public void Climb()
    {
        EditJointDistance(Speed);

        if (DistanceJoint2D.distance < MinDistance)
        {
            DisableHook();
        }
    }

    public void EditJointDistance(float Speed)
    {
        DistanceJoint2D.distance -= Speed * Time.deltaTime;
    }
    
    void OnTriggerEnter2D(Collider2D GameObject)
    {
        if (LayerMask == (LayerMask | (1 << GameObject.gameObject.layer)))
        {
            PlatformInside = GameObject;
        }
    }

    void OnTriggerExit2D(Collider2D GameObject)
    {
        if (LayerMask == (LayerMask | (1 << GameObject.gameObject.layer)))
        {
            PlatformInside = null;
        }
    }
}