using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    private float randomPos = 9;
    public int enemyCount;
    public int waveCount;
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<EnemyScripts>().Length;

        if(enemyCount == 0)
        {
            waveCount++;
            SpawnEnemyWave(waveCount);
            Instantiate(powerupPrefab, GenarateSpawnPosition(), powerupPrefab.transform.rotation);
        }
    }
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for(int i = 0; i < enemiesToSpawn ; i++)
        {
            Instantiate(enemyPrefab, GenarateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }
    private Vector3 GenarateSpawnPosition()
    {
        float spawnPosX = Random.Range(-randomPos, randomPos);
        float spawnPosZ = Random.Range(-randomPos, randomPos);

        Vector3 spawnPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return spawnPos;
    }

    
}
