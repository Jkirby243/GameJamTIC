using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadBullet : MonoBehaviour
{
    public float bulletspeed;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.forward * bulletspeed; 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            //Deal Damage
        }
        //Do other decals and stuff
        //Make either pop or other shit
        Destroy(gameObject);
    }
}
