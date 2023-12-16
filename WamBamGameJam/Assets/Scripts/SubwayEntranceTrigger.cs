using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubwayEntranceTrigger : MonoBehaviour
{

    [SerializeField] private GameObject door; 

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            var anim = door.GetComponent<Animator>();
            anim.SetTrigger("OpenDoor");
        }
    }

}
