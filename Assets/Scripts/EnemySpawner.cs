using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public GameObject enemyType;
    public GameObject enemyType2;

    public float spawnTime = 3f;
    public Transform[] spawnPoints;


	// Use this for initialization
	void Start () {
        // can be changed to use random intervals by calling Invoke() in Invoke()
        InvokeRepeating("Spawn", spawnTime, spawnTime);
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
        }
    }
}
