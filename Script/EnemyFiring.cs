using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFiring : MonoBehaviour {
	private Vector2 fireDirection;
	private GameObject player;
	private EnemyBehaviour enemyBehaviour;
	public GameObject enemyArrow;
	private Vector3 arrowRotation;
	private float timePassedSinceLast;
	private float delayFire = 2f;
	// Use this for initialization
	void Awake() {
		player = GameObject.FindGameObjectWithTag ("Player");
		enemyBehaviour = GetComponentInParent<EnemyBehaviour> ();
	}
	void Start () {
		timePassedSinceLast = delayFire;
	}
	
	// Update is called once per frame
	void Update () {
		if (enemyBehaviour.isEnemyAttacking && timePassedSinceLast >= delayFire) {
			GameObject arrow = GameObject.Instantiate (enemyArrow);
			arrow.transform.position = transform.position;
			Vector2 direction = player.transform.position - arrow.transform.position;
			arrow.GetComponent<EnemyArrow> ().setArrowDirection (direction);
			timePassedSinceLast = 0f;
		}	
		if (timePassedSinceLast < delayFire) {
			timePassedSinceLast += Time.deltaTime;
		}
	}
}
