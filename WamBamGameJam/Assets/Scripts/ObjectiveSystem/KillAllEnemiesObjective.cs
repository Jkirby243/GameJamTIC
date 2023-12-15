using System;
using UnityEngine;

public class KillAllEnemiesObjective : Objective
{

    [Tooltip("Choose whether you need to kill every enemy or only a minimum amount")]
    public bool mustKillAllEnemies = true;

    [Tooltip("If MustKillAllEnemies is false, this is the amount of enemy kills required")]
    public int KillsToCompleteObjective = 1;

    private int _killTotal;
    private int _totalEnemies = 1; 

    protected override void Start()
    {
        base.Start();
        if (string.IsNullOrEmpty(title))
            title = "Eliminate " + (mustKillAllEnemies ? "all the" : KillsToCompleteObjective.ToString()) +
                    " enemies";
        TestEnemyScript.OnEnemyKilled += HandleEnemyKilled;
        //We would subscribe to the events in each invidual objective scripts here
        /*Enemy.OnEnemyKilled += HandleEnemyKilled; 
         * 
         */
    }

    private void HandleEnemyKilled()
    {
        _killTotal++;
        print(_killTotal + " == " + _totalEnemies);
        if (_killTotal == _totalEnemies)
        {
            //Complete Objective
            print("Killed all enemies!");
            CompleteObjective();
        }
    }
}
