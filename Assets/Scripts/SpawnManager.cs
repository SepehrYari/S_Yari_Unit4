using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject powerUpPrefab;
    public GameObject enemyPrefab;
    private float spawnRange = 8.5f;
    private int enemyCount;

    private int waveNumber = 1;
    // Start is called before the first frame update
    void Start()
    {
        //Vector3 GenPos = GenerateSpawnPosition();
        SpawnWave(waveNumber);
        

    }

    private void Update()
    {
        
        enemyCount = FindObjectsOfType<Enemy>().Length;
        //Debug.Log(FindObjectsOfType<Enemy>().Length);
        Debug.Log(enemyCount);

        if(enemyCount == 0)
        {
            waveNumber++;
            SpawnWave(waveNumber);
        }
        
    }

    void SpawnWave(int enemyNum)
    {
        Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation);

        for (int i = 0; i < enemyNum; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }


    Vector3 GenerateSpawnPosition()
    {
        float xPos = Random.Range(-spawnRange, spawnRange);
        float zPos = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnPos = new Vector3(xPos, enemyPrefab.transform.position.y, zPos);
        return spawnPos;
    }


}
