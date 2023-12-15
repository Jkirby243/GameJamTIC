using System;
using UnityEngine;

public class TestEnemyScript : MonoBehaviour
{

    public static event Action OnEnemyKilled;

    [SerializeField] private GameObject[] enemies; 

    private void Start()
    {

        GameObject[] enemiesTemp = GameObject.FindGameObjectsWithTag("Enemy");
        enemies = new GameObject[enemiesTemp.Length];
        for(int i = 0; i < enemiesTemp.Length; i++)
        {
            enemies[i] = enemiesTemp[i];
        }

        KillAllEnemiesNow();
    }

    public void KillAllEnemiesNow()
    {
        print("Enemy Killed");
        OnEnemyKilled.Invoke();
    }

}
