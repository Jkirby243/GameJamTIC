using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponAssigner : MonoBehaviour
{

    [SerializeField]
    private Weapon Weaponname; //name of the weapon, each gun has a weapon name assigned to it

    [SerializeField] private GameObject instructionsText;
    [SerializeField] private GameObject gunCanvas; 

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Player has entered Weapon Trigger Box");
            var weaponManager = other.GetComponent<WeaponsManager>();
            if(Weaponname.ToString().Contains("Pistol"))
            {
                weaponManager.SetCowboyTriggerZone(true);
                instructionsText.SetActive(true);
                instructionsText.GetComponent<TextMeshProUGUI>().SetText("Press E to Pickup");
                gunCanvas.SetActive(true);
            }
            else if(Weaponname.ToString().Contains("Revolver"))
            {
                weaponManager.SetSenatorTriggerZone(true);
                instructionsText.SetActive(true);
                instructionsText.GetComponent<TextMeshProUGUI>().SetText("Press E to Pickup");
                gunCanvas.SetActive(true);
            }
            else
            {
                weaponManager.SetTweakerTriggerZone(true);
                instructionsText.SetActive(true);
                instructionsText.GetComponent<TextMeshProUGUI>().SetText("Press E to Pickup");
                gunCanvas.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player has exited Weapon Trigger Box");
            var weaponManager = other.GetComponent<WeaponsManager>();
            if (Weaponname.ToString().Contains("Pistol"))
            {
                weaponManager.SetCowboyTriggerZone(false);
                instructionsText.SetActive(false);
                gunCanvas.SetActive(false);
            }
            else if (Weaponname.ToString().Contains("Revolver"))
            {
                weaponManager.SetSenatorTriggerZone(false);
                instructionsText.SetActive(false);
                gunCanvas.SetActive(false);
            }
            else
            {
                weaponManager.SetTweakerTriggerZone(false);
                instructionsText.SetActive(false);
                gunCanvas.SetActive(false);
            }
        }
    }


}
