using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner2 : MonoBehaviour {
	public GameObject enemySpawn2;
	private float spawnMin = 10f;
	private float spawnMax = 20f;
	//private float timeForStart = 5f;
	//private float startCountdown = 0f;
	// Use this for initialization
	void Start () {
		SpawnStart();
	}

	void SpawnStart(){
		Instantiate (enemySpawn2, transform.position, Quaternion.Euler (0, 0, 180));
		Invoke ("SpawnStart", Random.Range (spawnMin, spawnMax));
	}
}
