using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public GameObject enemyType;
    public GameObject enemyType2;

    public Transform[] spawnPoints;

    const float minSpawnTime = 1f;
    const float maxSpawnTime = 5f;
    float currentMinSpawnTime;
    float spawnTime;
    float spawnTimeDecrement = 0.1f;

    // Use this for initialization
    void Start () {
        spawnTime = maxSpawnTime;
        currentMinSpawnTime = maxSpawnTime - 0.1f;

        Invoke("Spawn", minSpawnTime);//spawn first enemy right away
	}

    void Spawn()
    {
        GameObject randomEnemyType = (Random.Range(0, 2) == 0) ? enemyType : enemyType2;
        // FIXME: if player is dead, do not spawn
        if (spawnPoints.Length > 0) {
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            GameObject enemy = Instantiate(
                randomEnemyType,
                spawnPoints[spawnPointIndex].position,
                spawnPoints[spawnPointIndex].rotation
            );
            enemy.transform.parent = transform;

            //Spawn time:

            spawnTime = Random.Range(currentMinSpawnTime, maxSpawnTime);
            if (randomEnemyType == enemyType2)//enemy2 is a bit slower so delay a bit
            {
                spawnTime += 0.5f;     
            }

            currentMinSpawnTime -= spawnTimeDecrement;
            if (currentMinSpawnTime < minSpawnTime)
            {
                currentMinSpawnTime = minSpawnTime;
            }

            //print(spawnTime + " curmin:" + currentMinSpawnTime);

            Invoke("Spawn", spawnTime);
        }
    }
}
