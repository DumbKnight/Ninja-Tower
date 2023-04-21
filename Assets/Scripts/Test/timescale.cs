using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timescale : MonoBehaviour
{
    public float time;

    private void Update()
    {
        Time.timeScale = time;
    }
}
