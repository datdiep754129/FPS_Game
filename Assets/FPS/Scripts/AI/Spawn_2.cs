using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.FPS.AI;

public class Spawn_2 : MonoBehaviour
{
    public List<GameObject> autoBot;
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
        enemyCount = FindObjectsOfType<EnemiesLocation_2>().Length;
        if (enemyCount < 10 && hasCooldown == false)
        {
            hasCooldown = true;
            StartCoroutine(RespawnCooldown());
            waveNumber++;
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
        int randomBot = Random.Range(1, autoBot.Count);
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(autoBot[randomBot], GenerateSpawnPosition(), autoBot[randomBot].transform.rotation);
        }
    }
}
