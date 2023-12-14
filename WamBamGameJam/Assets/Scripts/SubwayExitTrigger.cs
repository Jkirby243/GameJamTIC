using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubwayExitTrigger : MonoBehaviour
{
    [SerializeField] private GameObject door;
    [SerializeField] private bool doorClosed; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            var anim = door.GetComponent<Animator>();
            anim.SetTrigger("CloseDoor");
            doorClosed = true; 
        }
    }

    public bool GetIsDoorClosed()
    {
        return doorClosed;
    }
}
