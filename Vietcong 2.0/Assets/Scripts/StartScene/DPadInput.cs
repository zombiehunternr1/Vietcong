using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DPadInput : MonoBehaviour
{
    public static bool left;
    public static bool right;

    private int lastDpadX = 0;

    //This constantly gets the Axis values from the Input Manager with the name DPadX
    void Update()
    {
        if (Input.GetAxis("DPadX") == 1 && lastDpadX != 1) { right = true; } else { right = false; }
        if (Input.GetAxis("DPadX") == -1 && lastDpadX != -1) { left = true; } else { left = false; }
    }
}