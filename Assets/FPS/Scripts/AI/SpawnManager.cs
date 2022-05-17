using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.FPS.AI;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> autoBot;
    public bool hasCooldown;
    public int respawnCooldown = 5;
    public float positionX_A;
    public float positionZ_A;
    public float positionX_B;
    public float positionZ_B;
    public int Enemies;
    public int waveNumber = 1;
    public int Checkbot = 0;
    public int EnemiesToSpawn;
    public string tag;

    public bool waveUp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int randomBot = Random.Range(0, autoBot.Count);
        checkWaveUp();
        autoBot[randomBot].gameObject.tag = tag;
    }
    IEnumerator RespawnCooldown()
    {
        yield return new WaitForSeconds(respawnCooldown);
        hasCooldown = false;
        Debug.Log("Spawn");
        if (waveUp)
        {
            SpawnEnemyWave(waveNumber);
        }
        else
        {
            SpawnRandomEnemies();
        }

    }

    void checkWaveUp()
    {
        Enemies = GameObject.FindGameObjectsWithTag(tag).Length;
        if (waveUp == true)
        {
            if (Enemies == 0 && hasCooldown == false)
            {
                hasCooldown = true;
                StartCoroutine(RespawnCooldown());
                waveNumber++;
            }
            /**
            if (enemyCount == 0 && hasCooldown == false)
            {
                hasCooldown = true;
                StartCoroutine(RespawnCooldown());
                waveNumber++;
            }
            **/
        }
        if (waveUp != true)
        {
            if (Enemies < EnemiesToSpawn && hasCooldown == false)
            {
                hasCooldown = true;
                StartCoroutine(RespawnCooldown());
            }
        }
        
    }
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(positionX_A, positionX_B);
        float spawnPosZ = Random.Range(positionZ_A, positionZ_B);
        Vector3 randomPos = new Vector3(spawnPosX, this.transform.position.y, spawnPosZ);
        return randomPos;
    }
    void SpawnRandomEnemies()
    {
        int randomBot = Random.Range(1, autoBot.Count);
        Instantiate(autoBot[randomBot], GenerateSpawnPosition(), autoBot[randomBot].transform.rotation);
        Debug.Log("Spawn + " + randomBot);
    }
    void SpawnEnemyWave(int enemiesToSpawn)
    {

        if (waveNumber <= 4 && Checkbot <= autoBot.Count)
        {
            for (int i = 0; i < enemiesToSpawn; i++)
            {
                Instantiate(autoBot[Checkbot], GenerateSpawnPosition(), autoBot[Checkbot].transform.rotation);
            }
        }
        else if(waveNumber >4 && waveNumber <= 7 && Checkbot <= autoBot.Count)
        {
            if (waveNumber == 5)
            {
                Checkbot++;
            }
            for (int i = 0; i < enemiesToSpawn; i++)
            {
                Instantiate(autoBot[Checkbot], GenerateSpawnPosition(), autoBot[Checkbot].transform.rotation);
            }
        }
        else if(waveNumber > 7 && waveNumber < 11 && Checkbot <= autoBot.Count)
        {
            if (waveNumber == 8)
            {
                Checkbot++;
            }

            for (int i = 0; i < enemiesToSpawn; i++)
            {
                Instantiate(autoBot[Checkbot], GenerateSpawnPosition(), autoBot[Checkbot].transform.rotation);
            }
        }
        else
        {
            if(waveNumber == 12)
            {
                Checkbot++;
            }
            for (int i = 0; i < enemiesToSpawn; i++)
            {
                Instantiate(autoBot[Checkbot], GenerateSpawnPosition(), autoBot[Checkbot].transform.rotation);
            }
        }
    }
}
