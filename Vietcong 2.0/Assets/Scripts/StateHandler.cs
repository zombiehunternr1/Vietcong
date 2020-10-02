using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateHandler : MonoBehaviour
{
    private float canAct;
    public bool CanAct { get { return canAct <= 0; } }
    
    void Update()
    {
        if(canAct > 0)
        {
            canAct -= Time.deltaTime;
        }
    }

    public void SetCanAct(float timer)
    {
        canAct = timer;
    }
}
