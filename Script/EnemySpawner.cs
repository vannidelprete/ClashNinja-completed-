using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
	public GameObject enemySpawn;
	private float spawnMax = 20f;
	private float spawnMin = 10f;
	// Use this for initialization
	void Start () {
		SpawnStart ();
	}

	void SpawnStart () {
		Instantiate (enemySpawn, transform.position, Quaternion.identity);
		Invoke("SpawnStart", Random.Range(spawnMin,spawnMax));
	}
}
