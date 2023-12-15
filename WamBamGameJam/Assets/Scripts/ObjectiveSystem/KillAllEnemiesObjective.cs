using System;
using UnityEngine;

public class KillAllEnemiesObjective : Objective
{

    [Tooltip("Choose whether you need to kill every enemy or only a minimum amount")]
    public bool mustKillAllEnemies = true;

    [Tooltip("If MustKillAllEnemies is false, this is the amount of enemy kills required")]
    public int KillsToCompleteObjective = 1;

    public int _totalMaxEnemies = 6; 

    private int _killTotal;

    [Space]
    [Header("Enemy Spawn Attributes Associated with This Objective")]
    public bool randomizeEnemies;
    public bool enemiesPreSpawned;
    public bool continuousSpawning;

    protected override void Start()
    {
        base.Start();
        if (string.IsNullOrEmpty(title))
            title = "Eliminate " + (mustKillAllEnemies ? "all the" : KillsToCompleteObjective.ToString()) +
                    " enemies";
        Enemy.OnEnemyKilled += HandleEnemyKilled;
        //We would subscribe to the events in each invidual objective scripts here
        /*Enemy.OnEnemyKilled += HandleEnemyKilled; 
         * 
         */
    }

    private void HandleEnemyKilled()
    {
        _killTotal++;
        //print(_killTotal + " == " + _totalMaxEnemies);
        if (_killTotal == _totalMaxEnemies)
        {
            //Complete Objective
            //print("Killed all enemies!");
            CompleteObjective();
        }
    }

    protected override void ChangeEnemySpawnBehavior(bool randomize, bool enemiesPreSpawn, bool continousSpawn)
    {
        base.ChangeEnemySpawnBehavior(randomizeEnemies, enemiesPreSpawned, continuousSpawning);


    }
}
