using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script per lo spawning dei nemici

public class EnemySpawner : MonoBehaviour {
	public GameObject enemySpawn;
	private float spawnMax = 15f;
	private float spawnMin = 5f;

	void Start () {
		SpawnStart ();
	}

	void SpawnStart () {
		Instantiate (enemySpawn, transform.position, Quaternion.identity);
		Invoke("SpawnStart", Random.Range(spawnMin,spawnMax));
	}
}
