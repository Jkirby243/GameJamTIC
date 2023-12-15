using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SubwayManager : MonoBehaviour
{

    private bool playerReady;
    private bool fadeIn; 
    [SerializeField] GameObject fadeImage;
    [SerializeField] private GameObject instructionsText;
    [SerializeField] private GameObject _player;
    [SerializeField] private LevelManager levelManager; 

    public float alpha;
    private float lerpDuration = 15f;
    private float currentTime = 0f; 

    private void Start()
    {
        //StartCoroutine(Fade("In")); //this should be moved to the level manager
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            _player = other.gameObject; 
            if(other.GetComponent<WeaponsManager>().GetActiveGun() != null)
            {
                playerReady = true;
                instructionsText.SetActive(true);
                instructionsText.GetComponent<TextMeshProUGUI>().SetText("Press E to Exit");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerReady = false;
            instructionsText.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (playerReady && Input.GetKeyDown(KeyCode.E))
        {
            instructionsText.SetActive(false);
            levelManager.StartFadeCoroutine("Out", "level");
            playerReady = false; 
        }
    }
}
