using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KOTHObjective : Objective
{
    [Header("KoTH Objective Properties")]
    [SerializeField] private float totalPercentageToCapture = 100f;
    [SerializeField] private float captureRate = 2;
    [SerializeField] private float holdTime = 3f;
    [Space]
    [SerializeField] private TextMeshProUGUI capturePercentageDisplay;

    [Space]
    [Header("Enemy Spawn Attributes Associated with This Objective")]
    public bool randomizeEnemies;
    public bool enemiesPreSpawned;
    public bool continuousSpawning;
    
    private GameObject objectivePoint;
    private bool onPoint;
    private bool leftPoint;
    private bool pointCaptured;

    [SerializeField] private float currentCapturePercentage;

    protected override void Start()
    {
        base.Start();
        if (string.IsNullOrEmpty(title))
            title = "Defend and Capture the point";

        KoTHPointCapture.CapturingPoint += HandleCapturingPoint;
        KoTHPointCapture.LeavingPoint += HandleLeavingPoint;
        pointCaptured = false;
        currentCapturePercentage = 0;
        capturePercentageDisplay.gameObject.SetActive(false);
        ChangeEnemySpawnBehavior(randomizeEnemies, enemiesPreSpawned, continuousSpawning);
    }

    private void HandleCapturingPoint()
    {
        onPoint = true;
        leftPoint = false; 
        capturePercentageDisplay.gameObject.SetActive(true);
    }

    private void HandleLeavingPoint()
    {
        leftPoint = true;
        onPoint = false; 
    }

    private void Update()
    {
        if(onPoint)
        {
            if (currentCapturePercentage < totalPercentageToCapture && !pointCaptured)
            {
                currentCapturePercentage += Time.deltaTime * captureRate;
                currentCapturePercentage = Mathf.Clamp(currentCapturePercentage, 0, 100);
                capturePercentageDisplay.SetText(((int)currentCapturePercentage).ToString() + "%");
            }
            else
            {
                //ObjectiveCompleted
                pointCaptured = true;
                capturePercentageDisplay.gameObject.SetActive(false);
                CompleteObjective();
            }
        }
        else if(leftPoint)
        {
            StartCoroutine(HoldOnPercentage());
            if (currentCapturePercentage < totalPercentageToCapture && !pointCaptured)
            {
                currentCapturePercentage -= Time.deltaTime * captureRate;
                currentCapturePercentage = Mathf.Clamp(currentCapturePercentage, 0, 100);
                capturePercentageDisplay.SetText(((int)currentCapturePercentage).ToString() + "%");
            }

        }
    }

    IEnumerator HoldOnPercentage()
    {
        yield return new WaitForSeconds(holdTime);

    }

    protected override void ChangeEnemySpawnBehavior(bool randomize, bool enemiesPreSpawn, bool continousSpawn)
    {
        base.ChangeEnemySpawnBehavior(randomize, enemiesPreSpawn, continousSpawn);
    }
}
