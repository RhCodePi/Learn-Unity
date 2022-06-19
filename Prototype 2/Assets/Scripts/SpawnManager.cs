using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefaps;
    private float spawnRangeX = 6;
    private float spawnPosZ = 20;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    
    void Update()
    {

    }

    void SpawnRandomAnimal()
    {
        int animalIndex =  Random.Range(0, animalPrefaps.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);

        Instantiate(animalPrefaps[animalIndex], spawnPos, animalPrefaps[animalIndex].transform.rotation);
    }
}
