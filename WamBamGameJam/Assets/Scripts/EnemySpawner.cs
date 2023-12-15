using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EnemySpawner : MonoBehaviour
{

    [Header("Enemy Spawner Properties")]
    [Space]

    [SerializeField] private GameObject[] enemyPrefab;

    [Space]

    [SerializeField] private float levelStartWaitTime; 

    [SerializeField] private float spawnRate = 1f;

    [SerializeField] private int maxEnemyCount = 6;

    [HideInInspector]
    public int currentEnemyCount = 0; 

    [Space]

    [Header("Type of Spawning")]
    [Space]

    [SerializeField] public bool randomEnemy;

    [SerializeField] public bool enemiesInstantiated;

    [SerializeField] public bool continuouslySpawningEnemies; 

    

    #region Private Properties
    private Transform[] enemySpawnPoints; 
    private bool canSpawn;
    private float spawnTimer;
    private int randomVal;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        canSpawn = false;
        spawnTimer = levelStartWaitTime;
        enemySpawnPoints = new Transform[transform.childCount];

        int children = transform.childCount;
        enemySpawnPoints = new Transform[children];
        for(int i = 0; i < children; i++)
        {
            enemySpawnPoints[i] = transform.GetChild(i);
        }

        if(enemiesInstantiated)
        {
            if(randomEnemy)
            {
                for(int j = 0; j < maxEnemyCount; j++)
                {
                    for (int i = 0; i < enemySpawnPoints.Length; i++)
                    {
                        currentEnemyCount++;
                        randomVal = Random.Range(0, enemyPrefab.Length);
                        Instantiate(enemyPrefab[randomVal], enemySpawnPoints[i].position, Quaternion.identity);
                    }
                }
            }
            else
            {
                for (int j = 0; j < maxEnemyCount; j++)
                {
                   for (int i = 0; i < enemySpawnPoints.Length; i++)
                    {
                        currentEnemyCount++;
                        Instantiate(enemyPrefab[0], enemySpawnPoints[i].position, Quaternion.identity);
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime; 
        if(spawnTimer <= 0 && continuouslySpawningEnemies)
        {
            StartCoroutine(Spawner());
            spawnTimer = spawnRate; 
;       }
    }

    private IEnumerator Spawner()
    {
        if(randomEnemy)
          {
            
            for(int i = 0; i < enemySpawnPoints.Length; i++)
            {
                if(currentEnemyCount >= maxEnemyCount)
                {
                    print("Reached Max Enemy Count");
                    break;
                }
                else
                {
                    currentEnemyCount++;
                    randomVal = Random.Range(0, enemyPrefab.Length);
                    Instantiate(enemyPrefab[randomVal], enemySpawnPoints[i].position, Quaternion.identity);
                     
                }
            }
            
            yield return new WaitForSeconds(spawnRate);
        }
        else
        {
            for (int i = 0; i < enemySpawnPoints.Length; i++)
            {
                if (currentEnemyCount >= maxEnemyCount)
                {
                    break;
                }
                else
                {
                    currentEnemyCount++;
                    Instantiate(enemyPrefab[0], enemySpawnPoints[i].position, Quaternion.identity);
                }
            }
            yield return new WaitForSeconds(spawnRate);
        }

    }
}