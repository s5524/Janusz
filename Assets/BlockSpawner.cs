using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{

    public Transform[] spawnPoints;
    public GameObject block;
    // Start is called before the first frame update
    float timeSpawning = 2f;
    float timeBetwenWaves = 5f;
    void Start()
    {
        Spawn();

    }
    private void Update()
    {
        if (Time.time >= timeSpawning)
        {
            Spawn();
            timeSpawning = Time.time + timeBetwenWaves;
                
        }
    }
    private void Spawn()
    {
        int randomNumber = UnityEngine.Random.Range(0, spawnPoints.Length);

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (randomNumber != i)
            {
                var bloc = Instantiate(block, spawnPoints[i].position, Quaternion.identity, spawnPoints[i].transform);


            }
        }
    }
}
