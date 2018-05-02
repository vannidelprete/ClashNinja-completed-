using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Gestione tempistiche di attacco del guerriero drago

public class EnemyDragonFiring : MonoBehaviour {
	private Vector2 fireDirection;
	private GameObject player;
	private EnemyDragonBehaviour enemyBehaviour;
	public GameObject enemyFireBall;
	private Vector3 arrowRotation;
	private float timePassedSinceLast;
	private float delayFire = 0.767f;

	void Awake() {
		player = GameObject.FindGameObjectWithTag ("Player");
		enemyBehaviour = GetComponentInParent<EnemyDragonBehaviour> ();
	}
	void Start () {
		timePassedSinceLast = delayFire;
	}


	void Update () {
		if (player != null) {
			if (!enemyBehaviour.isDead) {
				if (enemyBehaviour.isEnemyAttacking && timePassedSinceLast >= delayFire) {
					GameObject fireBall = GameObject.Instantiate (enemyFireBall);
					fireBall.transform.position = transform.position;
					Vector2 direction = player.transform.position - fireBall.transform.position;
					fireBall.GetComponent<EnemyFireBall> ().setArrowDirection (direction);
					timePassedSinceLast = 0f;
				}	
				if (!enemyBehaviour.isEnemyAttacking) {
					timePassedSinceLast = 0f;
				}
				if (timePassedSinceLast < delayFire) {
					timePassedSinceLast += Time.deltaTime;
				}
			}
		}
	}
}
