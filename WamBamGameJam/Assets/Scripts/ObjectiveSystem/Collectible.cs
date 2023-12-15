using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Collectible : MonoBehaviour
{

    public static event Action OnItemPickUp;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PickUp();
        }
    }

    private void PickUp()
    {
        //also add in item animation and sound effects
        OnItemPickUp.Invoke();
        Destroy(gameObject);
    }
}
