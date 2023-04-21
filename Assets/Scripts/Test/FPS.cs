using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPS : MonoBehaviour
{
    public Text FPSText;
    public void Update()
    {
        FPSText.text = "" + 1f / Time.deltaTime;
    }
}
