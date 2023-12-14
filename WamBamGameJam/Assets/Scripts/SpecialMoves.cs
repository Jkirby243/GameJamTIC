using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialMoves : MonoBehaviour
{
    public bool revolver;
    public bool sword;
    public int headshots = 0;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //SpecialShot
        if (revolver)
        {
            if (Input.GetMouseButtonDown(1))
            {
                if (headshots != 0)
                {
                    //Gets the closest enemy to hit with richochet
                    GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
                    GameObject closest = enemies[0];
                    float dist = Vector3.Distance(player.transform.position, closest.transform.position);
                    foreach (GameObject enemy in enemies)
                    {
                        if (Vector3.Distance(player.transform.position, enemy.transform.position) < dist)
                        {
                            closest = enemy;
                            dist = Vector3.Distance(player.transform.position, enemy.transform.position);
                        }
                    }

                    //Will now loop through the gameobjects to find the next closest to the last shot enemy for each headshot dealt
                    List<GameObject> kill = new List<GameObject>();
                    kill.Add(closest);
                    dist = float.MaxValue;
                    headshots--;
                    for (int i = headshots; i > 0; --i)
                    {
                        Debug.Log("HeadShotloop for " + kill[kill.Count - 1] + " on loop " + i);
                        foreach (GameObject e in enemies)
                        {
                            if (Vector3.Distance(kill[kill.Count - 1].transform.position, e.transform.position) < dist)
                            {
                                if (kill.Contains(e) == false)
                                {
                                    Debug.Log("Adding " + e.name + " To ricochet list");
                                    dist = Vector3.Distance(kill[kill.Count - 1].transform.position, e.transform.position);
                                    kill.Add(e);
                                    break;
                                }
                            }
                        }
                        dist = float.MaxValue;
                    }
                    Debug.Log(kill);
                    foreach (GameObject e in kill)
                    {
                        EnemyHealth tmp = e.GetComponent<EnemyHealth>();
                        tmp.DealDamage(tmp.health, tmp.transform.position);
                    }
                }
                headshots = 0;
            }
        }
    }

    public void AddHeadshot()
    {
        if (revolver)
        {
            ++headshots;
        }
    }
}
