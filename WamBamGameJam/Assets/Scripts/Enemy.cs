using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class Enemy : MonoBehaviour
{

    public static event Action OnEnemyKilled;

    //Private EnemyHealth Health
    private NavMeshAgent Nav;
    public float shootingtime;
    private float shoottimer = 0;
    public float range;
    private GameObject Player;
    public float speed;
    public float rotationspeed;
    public Animator animator;
    private bool shooting = false;
    public LayerMask mask;
    public GameObject Firepoint;
    public GameObject bullet;
    public bool melee;

    public int health;
    public GameObject DamageNumber;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectsWithTag("Player")[0];
        Nav = GetComponent<NavMeshAgent>();
        Nav.speed = speed;
        Nav.angularSpeed = rotationspeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (shooting == false)
        {
            Nav.SetDestination(Player.transform.position);
        }
        if(shooting == true && !melee)
        {
            transform.LookAt(Player.transform.position);
        }
        if (!melee)
        {
            Debug.DrawRay(transform.position, (Player.transform.position - transform.position), Color.red, .01f);
            if (Physics.Raycast(transform.position, (Player.transform.position - transform.position), out RaycastHit hit, range))
            {
                if (hit.transform.tag == "Player")
                {
                    Nav.speed = 0;
                    shooting = true;
                    //Debug.Log("SHoot!");
                }
                if (Time.time > shoottimer + shootingtime)
                {

                    shoottimer = Time.time;
                    Instantiate(bullet, Firepoint.transform.position, transform.rotation);

                }
            }
            else
            {
                Nav.speed = speed;
                shooting = false;
            }
        }
        if (melee)
        {
            Debug.DrawRay(transform.position, transform.forward * 1.5f, Color.red,.01f);
            if (Physics.Raycast(transform.position, (Player.transform.position - transform.position), out RaycastHit hit, 1f))
            {
                if (hit.transform.tag == "Player")
                {
                    Nav.speed = 0;
                    
                    //Debug.Log("SHoot!");
                }
                if (!shooting)
                {
                    
                    StartCoroutine(wait());
                    shooting = true;
                    //shoottimer = Time.time;
                    //finish animation

                }
            }
            else
            {
                if (!shooting)
                {
                    Nav.speed = speed;
                }
            }
        }
    }

    public void DealDamage(int damage, Vector3 pos)
    {
        health -= damage;
        GameObject numb = Instantiate(DamageNumber, pos, Quaternion.identity);
        numb.GetComponent<Number>().value = damage;
        //Debug.Log("Damage is " + damage.ToString() + " value is " + numb.GetComponent<Number>().value.ToString());
        numb.GetComponent<Number>().text.text = damage.ToString();
        if(health<= 0)
        {
            Death();
        }
    }

    public void HeadShot(int damage, Vector3 pos)
    {
        //Debug.Log("deadling headshot+");
        float headdamage = (float)damage * 2.5f;
        health -= Mathf.RoundToInt(headdamage);
        GameObject numb = Instantiate(DamageNumber, pos, Quaternion.identity);
        numb.GetComponent<Number>().value = Mathf.RoundToInt(headdamage);
        //Debug.Log("Damage is " + Mathf.RoundToInt(headdamage).ToString() + " value is " + numb.GetComponent<Number>().value.ToString());
        numb.GetComponent<Number>().text.text = Mathf.RoundToInt(headdamage).ToString();
    }

    public void Death()
    {
        if(OnEnemyKilled!= null)
        {
            OnEnemyKilled.Invoke();
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        //print("Enemy Died!");
        //Add animations here along with sound effects for death sequence
    }

    IEnumerator wait()
    {
        //Debug.Log("Call wait");
        yield return new WaitForSeconds(1);

        //Debug.Log(Vector3.Distance(transform.position, Player.transform.position));
        if (Vector3.Distance(transform.position, Player.transform.position) <= 1.5f)
        {
            //Debug.Log("DealDamage");
            Player.GetComponent<PlayerHealth>().DealDamage(10);
        }
        //Debug.Log("done swing");
        shooting = false;
    }

}
