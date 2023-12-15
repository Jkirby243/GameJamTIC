using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class KoTHPointCapture : MonoBehaviour
{
    public static event Action CapturingPoint;
    public static event Action LeavingPoint; 





    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(CapturingPoint != null)
            {
                CapturingPoint.Invoke();
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            if(LeavingPoint != null)
            {
                LeavingPoint.Invoke();
            }
            
        }
    }


}
