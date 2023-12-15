using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectObjective : Objective
{

    public int collectiblesToCompleteObjective = 3;
    public string nameOfCollectibles;
    private int _collectedTotal;

    [SerializeField] private GameObject collectiblePrefab;

    [Space]
    [Header("Enemy Spawn Attributes Associated with This Objective")]
    public bool randomizeEnemies;
    public bool enemiesPreSpawned;
    public bool continuousSpawning; 

    protected override void Start()
    {
        base.Start();
        if (string.IsNullOrEmpty(title))
            title = "Collect all " + collectiblesToCompleteObjective + " nameOfCollectibles";
        Collectible.OnItemPickUp += HandleItemPickUp;

        GameObject[] temp = GameObject.FindGameObjectsWithTag("Collectible");

        for(int i = 0; i < temp.Length; i++)
        {
            Instantiate(collectiblePrefab, temp[i].transform.position, Quaternion.identity);
        }
        ChangeEnemySpawnBehavior(randomizeEnemies, enemiesPreSpawned, continuousSpawning);
        //for(int i = 0; i < collectibleSpawnPoints)
    }

    private void HandleItemPickUp()
    {
        _collectedTotal++; 

        if(_collectedTotal >= collectiblesToCompleteObjective)
        {
            CompleteObjective();
        }
    }

    protected override void ChangeEnemySpawnBehavior(bool randomize, bool enemiesPreSpawn, bool continousSpawn)
    {
        base.ChangeEnemySpawnBehavior(randomize, enemiesPreSpawn, continousSpawn);
    }
}
