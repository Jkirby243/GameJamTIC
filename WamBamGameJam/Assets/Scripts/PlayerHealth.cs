using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static event Action OnPlayerDeath;

    public Slider healthBar; 
    public GameObject deathAnimation; 
    public int health;
    public int maxhealth;
    // Start is called before the first frame update
    void Start()
    {
        health = maxhealth;
        healthBar.value = health;
        deathAnimation.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DealDamage(int damage)
    {
        health -= damage;
        health = Mathf.Clamp(health, 0, maxhealth);
        healthBar.value = health; 
        if(health <= 0)
        {
            health = 0;
            print("Player died");
            StartCoroutine(PlayerDeathSequence());
            
        }
    }

    public void heal(int heal)
    {
        health += heal;
        health = Mathf.Clamp(health, 0, maxhealth);
        healthBar.value = health;
    }

    IEnumerator PlayerDeathSequence()
    {
        GetComponent<CharacterController>().enabled = false;
        deathAnimation.SetActive(true);
        yield return new WaitForSeconds(2f);
        OnPlayerDeath.Invoke();
    }
}
