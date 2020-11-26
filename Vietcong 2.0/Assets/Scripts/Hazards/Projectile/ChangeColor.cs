using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    private MeshRenderer ExclamationColor;
    public bool Change;
    private Color OriginalColor;

    void Start()
    {
        ExclamationColor = GetComponent<MeshRenderer>();
        OriginalColor = ExclamationColor.material.color;
    }

    void Update()
    {
        if (Change)
        {
            ExclamationColor.materials[0].color = Color.red;
        }
        else
        {
           ExclamationColor.materials[0].color = OriginalColor;
        }
    }
}
