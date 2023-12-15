using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float bulletspeed;
    private Rigidbody rb;
    private bool kill;
    private ParticleSystem particle;
    private float killtime = 3;
    private float timer = 0;
    private Vector3 killpos;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        particle = GetComponentInChildren<ParticleSystem>();
        rb.velocity = transform.forward * bulletspeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (killpos == null)
        {
            timer += Time.deltaTime;
            if (timer >= killtime)
            {
                kill = true;
            }
        }
        if(Vector3.Distance(transform.position, killpos) <= 1.5)
        {
            kill = true;
            particle.Stop();
        }
        if (kill)
        {
            if (particle.particleCount == 0)
            {
                Destroy(gameObject);
            }
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Bullet hit: " + other.name);
        if (other.tag != "Player" && other.tag != "MainCamera")
        {
            kill = true;
            particle.Stop();
            //Destroy(gameObject);
        }
    }

    public void setkillpos(Vector3 pos)
    {
        killpos = pos;
    }
}
