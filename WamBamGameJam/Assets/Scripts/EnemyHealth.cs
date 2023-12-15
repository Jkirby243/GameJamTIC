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

    }

    public void DealDamage(int damage, Vector3 pos)
    {
        health -= damage;
        GameObject numb = Instantiate(DamageNumber, pos, Quaternion.identity);
        numb.GetComponent<Number>().value = damage;
        Debug.Log("Damage is " + damage.ToString() + " value is " + numb.GetComponent<Number>().value.ToString());
        numb.GetComponent<Number>().text.text = damage.ToString();
    }

    public void HeadShot(int damage, Vector3 pos)
    {
        Debug.Log("deadling headshot+");
        float headdamage = (float)damage * 2.5f;
        health -= Mathf.RoundToInt(headdamage);
        GameObject numb = Instantiate(DamageNumber, pos, Quaternion.identity);
        numb.GetComponent<Number>().value = Mathf.RoundToInt(headdamage);
        Debug.Log("Damage is " + Mathf.RoundToInt(headdamage).ToString() + " value is " + numb.GetComponent<Number>().value.ToString());
        numb.GetComponent<Number>().text.text = Mathf.RoundToInt(headdamage).ToString();
    }
}
