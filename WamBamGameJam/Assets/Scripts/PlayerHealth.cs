using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int health;
    public int maxhealth;
    // Start is called before the first frame update
    void Start()
    {
        health = maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DealDamage(int damage)
    {
        health -= damage;
        if(health < 0)
        {
            health = 0;
        }
    }

    public void heal(int heal)
    {
        health += heal;
        if(health > maxhealth)
        {
            health = maxhealth;
        }
    }
}
