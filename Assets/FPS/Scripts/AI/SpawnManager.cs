using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.FPS.AI;

public class SpawnManager : MonoBehaviour
{
    public GameObject autoBot_1;
    public GameObject autoBot_2;
    public GameObject autoBot_3;
    public GameObject autoBot_4;
    public bool hasCooldown;
    public int respawnCooldown = 5;
    public float positionX_A;
    public float positionZ_A;
    public float positionX_B;
    public float positionZ_B;
    public int enemyCount;
    public int waveNumber = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<EnemiesLocation_1>().Length;
        if(enemyCount == 0 && hasCooldown == false)
        {
            hasCooldown = true;
            StartCoroutine(RespawnCooldown());
            waveNumber++;
            Debug.Log("E=0");
        }
    }
    IEnumerator RespawnCooldown()
    {
        yield return new WaitForSeconds(respawnCooldown);
        hasCooldown = false;
        Debug.Log("Spawn");
        SpawnEnemyWave(waveNumber);

    }
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(positionX_A, positionX_B);
        float spawnPosZ = Random.Range(positionZ_A, positionZ_B);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        if(waveNumber <= 5)
        {
            for (int i = 0; i < enemiesToSpawn; i++)
            {
                Instantiate(autoBot_1, GenerateSpawnPosition(), autoBot_1.transform.rotation);
            }
        }
        else if(waveNumber >5 && waveNumber <= 7)
        {
            for (int i = 0; i < enemiesToSpawn; i++)
            {
                Instantiate(autoBot_2, GenerateSpawnPosition(), autoBot_2.transform.rotation);
            }
        }
        else if(waveNumber > 7 && waveNumber < 11)
        {
            for (int i = 0; i < enemiesToSpawn; i++)
            {
                Instantiate(autoBot_3, GenerateSpawnPosition(), autoBot_3.transform.rotation);
            }
        }
        else
        {
            for (int i = 0; i < enemiesToSpawn; i++)
            {
                Instantiate(autoBot_4, GenerateSpawnPosition(), autoBot_4.transform.rotation);
            }
        }
    }
}
