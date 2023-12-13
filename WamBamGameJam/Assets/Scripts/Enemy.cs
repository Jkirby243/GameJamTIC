using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    //Private EnemyHealth Health
    private NavMeshAgent Nav;
    public float shootingtime;
    public float range;
    private GameObject Player;
    public float speed;
    public float rotationspeed;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        Nav = GetComponent<NavMeshAgent>();
        Nav.speed = speed;
        Nav.angularSpeed = rotationspeed;
    }

    // Update is called once per frame
    void Update()
    {
        Nav.SetDestination(Player.transform.position);

        if(Physics.Raycast(transform.position, Player.transform.position, out RaycastHit hit, range, 0))
        {
            //SHOOT BULLET/BULLETS AT PLAYER!!!
        }
    }
}
