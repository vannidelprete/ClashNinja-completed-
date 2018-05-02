using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Gestione delle tempistiche di attacco del mago

public class EnemyWizardFiring : MonoBehaviour {
	private Vector2 fireDirection;
	private GameObject player;
	private EnemyWizardBehaviour enemyBehaviour;
	public GameObject[] enemySphere;
	private Vector3 arrowRotation;
	private float timePassedSinceLast;
	private float delayFire = 1.183f;

	void Awake() {
		player = GameObject.FindGameObjectWithTag ("Player");
		enemyBehaviour = GetComponentInParent<EnemyWizardBehaviour> ();
	}
	void Start () {
		timePassedSinceLast = delayFire;
	}

	void Update () {
		if (player != null) {
			if (!enemyBehaviour.isDead) {
				if (enemyBehaviour.isEnemyAttacking && timePassedSinceLast >= delayFire) {
					GameObject sphere = GameObject.Instantiate (enemySphere [Random.Range (0, enemySphere.GetLength (0))]);
					sphere.transform.position = transform.position;
					Vector2 direction = player.transform.position - sphere.transform.position;
					sphere.GetComponent<EnemySphere> ().setArrowDirection (direction);
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
