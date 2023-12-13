using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{

    public GameObject Player;
    public GameObject platform;
    // Start is called before the first frame update
    void Start()
    {
        platform = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MovePlatform(Transform point)
    {
        Player.GetComponent<CharacterController>().enabled = false;
        Player.transform.parent = platform.transform;
        Vector3 tmp = new Vector3(Player.transform.localPosition.x, Player.transform.localPosition.y, Player.transform.localPosition.z);
        Debug.Log(tmp);
        platform.transform.position = point.position;
        platform.transform.rotation = point.rotation;
        Debug.Log("Assigning: " + tmp);
        Player.transform.localPosition = tmp;
        Player.transform.SetParent(null);
        Player.GetComponent<CharacterController>().enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger ENTERED");
        if(other.tag == "Player")
        {
            Debug.Log("player set");
            Player = other.gameObject;
        }
    }
}
