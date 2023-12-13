using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMover : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] Opens;
    public Mover Platform;
    void Start()
    {
        Opens = GameObject.FindGameObjectsWithTag("Door");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Teleport");
            GameObject.FindGameObjectsWithTag("Player")[0].transform.position = Opens[0].transform.position;
        }
        //DEBUGSTUFF
        if (Input.GetKeyDown(KeyCode.I))
        {
            Platform.MovePlatform(Opens[0].transform);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            Platform.MovePlatform(Opens[1].transform);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            Platform.MovePlatform(Opens[2].transform);
        }
    }
}
