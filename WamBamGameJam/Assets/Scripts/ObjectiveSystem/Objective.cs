using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public abstract class Objective : MonoBehaviour
{
    public string title; //name of the objective that will be shown on the screen

    public string description; //explaining the objective that will be shown on the screen

    public bool isOptional; //is this quest optional?

    public float delayVisible; //delay before the objective is visible

    public bool isCompleted { get; private set;  }

    public TextMeshProUGUI titleText, descriptionText;

    public bool isBlocking() => !(isOptional || isCompleted);

    public static event Action<Objective> OnObjectiveCreated; 
    public static event Action<Objective> OnObjectiveCompleted;

    public static event Action onObjectiveCompleted;

    private EnemySpawner enemySpawner; 

    protected virtual void Start()
    {
        OnObjectiveCreated?.Invoke(this);
        //display title and objective here?
        enemySpawner = FindObjectOfType<EnemySpawner>();
        if(enemySpawner == null)
        {
            Debug.LogError("ERROR: UNABLE TO FIND ENEMY SPAWNER");
        }
    }

    public void GrabUIElements(TextMeshProUGUI objectiveTitleText, TextMeshProUGUI objectiveDescriptionText)
    {
        titleText = objectiveTitleText;
        descriptionText = objectiveDescriptionText;
    }

    public void UpdateObjective()
    {
        titleText.SetText("Objective: " + title);
        print("Title should be: " + title);
        descriptionText.SetText(description);
        print("Description should be: " + description);
    }

    public void CompleteObjective()
    {
        titleText.SetText(title + ": Complete");
        descriptionText.SetText("");
        isCompleted = true;
        onObjectiveCompleted.Invoke();
    }

    protected virtual void ChangeEnemySpawnBehavior(bool randomize, bool enemiesPreSpawn, bool continousSpawn)
    {
        enemySpawner.ChangeSpawnerBehavior(randomize, enemiesPreSpawn, continousSpawn);
    }

}
