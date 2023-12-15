using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ObjectiveManager : MonoBehaviour
{

    public GameObject[] Objectives;
    public Objective activeObjective; 
    private int randomVal;

    public TextMeshProUGUI objectiveTitleText, objectiveDescriptionText; 

    private void Start()
    {
        //We would subscribe to the events in each invidual objective scripts here
        /*Enemy.OnEnemyKilled += HandleEnemyKilled; 
         * Item.OnItemCollected += HandleItemCollected
         * CapturePoint.OnPointCapured += HandlePointcaptured
         * 
         */
        CreateNewObjective();

    }

    public void CreateNewObjective()
    {
        //need a random number generator to choose between the three types
        randomVal = Random.Range(0, Objectives.Length);
        print("Random Objective chosen: " + Objectives[randomVal].name);
        //after choosing an objective, insantiate that objective as a child
        var temp = Instantiate(Objectives[randomVal], this.transform);
        activeObjective = temp.GetComponent<Objective>();
        activeObjective.GrabUIElements(objectiveTitleText, objectiveDescriptionText);
        activeObjective.UpdateObjective();
        print("Ui Elements Updated");
    }
}
