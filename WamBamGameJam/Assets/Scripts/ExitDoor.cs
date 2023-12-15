using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ExitDoor : MonoBehaviour
{

    public bool objectiveComplete = false;
    [SerializeField] private GameObject instructionsText;
    [SerializeField] private LevelManager levelManager;

    private bool inLoadingOut; 

    private void Start()
    {
        Objective.onObjectiveCompleted += SetDoorToInteractable;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (objectiveComplete && !inLoadingOut && other.gameObject.tag == "Player")
        {
            instructionsText.SetActive(true);
            instructionsText.GetComponent<TextMeshProUGUI>().SetText("Press E to Exit");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            instructionsText.SetActive(false);
        }
        
    }

    private void SetDoorToInteractable()
    {
        objectiveComplete = true;
        inLoadingOut = false; 
    }

    private void Update()
    {
        if (objectiveComplete && Input.GetKeyDown(KeyCode.E))
        {
            inLoadingOut = true; 
            instructionsText.SetActive(false);
            levelManager.StartFadeCoroutine("Out", "subway");
            inLoadingOut = false; 
        }
    }

}
