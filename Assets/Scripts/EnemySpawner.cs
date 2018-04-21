using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public GameObject enemyType;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;


	// Use this for initialization
	void Start () {
        // can be changed to use random intervals by calling Invoke() in Invoke()
        InvokeRepeating("Spawn", spawnTime, spawnTime);
	}
	

    void Spawn()
    {
        // FIXME: if player is dead, do not spawn
        if (spawnPoints.Length > 0) {
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(enemyType, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        }
    }
}
