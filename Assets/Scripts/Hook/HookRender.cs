using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookRender : MonoBehaviour
{
    //Components
    [Header("Components")]

    public LineRenderer LineRenderer;
    //Components

    public void RenderLine(Vector2 StartPoint, Vector2 EndPoint)
    {
        LineRenderer.enabled = true;

        LineRenderer.SetPosition(0, StartPoint);
        LineRenderer.SetPosition(1, EndPoint);
    }

    public void Disable()
    {
        LineRenderer.enabled = false;
    }
}