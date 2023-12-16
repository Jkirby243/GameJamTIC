using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int health;
    public GameObject DamageNumber;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void DealDamage(int damage, Vector3 pos)
    {
        health -= damage;
        GameObject numb = Instantiate(DamageNumber, pos, Quaternion.identity);
        numb.GetComponent<Number>().value = damage;
        Debug.Log("Damage is " + damage.ToString() + " value is " + numb.GetComponent<Number>().value.ToString());
        numb.GetComponent<Number>().text.text = damage.ToString();
    }
}
