using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enmy;
    public GameObject pwrUp;
    public float spawnRate = 1f;
    private float _spawnRange = 7f;
    public int enemyCount = 3;
    public static bool isPowerUpUp;
    void Start()
    {
        InvokeRepeating("SpawnEnemy",2f,spawnRate);
    }

    public void SpawnEnemy()
    {
        float randX;
        float randZ;
        if (isPowerUpUp == false)
        {
            randX = Random.Range(-_spawnRange, _spawnRange);
            randZ = Random.Range(-_spawnRange, _spawnRange);
            Instantiate(pwrUp, new Vector3(randX,0,randZ), pwrUp.transform.rotation);
            isPowerUpUp = true;
        }
        
        for (int i = 0; i < enemyCount; i++)
        {
            randX = Random.Range(-_spawnRange, _spawnRange);
            randZ = Random.Range(-_spawnRange, _spawnRange);
            Vector3 spawnPoint = new Vector3(randX, 0, randZ);
            Instantiate(enmy, spawnPoint, enmy.transform.rotation);
        }
    }
}
