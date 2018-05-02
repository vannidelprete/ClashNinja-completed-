using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//AI del guerriero drago

public class EnemyDragonBehaviour : MonoBehaviour {
	private GameObject player;
	private Animator animEnemy;
	private float speedEnemy = 4f;
	private float distToPlayer = 6f;
	private Vector3 playerPosition;
	public bool isEnemyAttacking;
	public bool isDead;
	private Rigidbody2D EnemyRb2D;

	void Awake(){
		player = GameObject.FindGameObjectWithTag("Player");
		animEnemy = GetComponent<Animator> ();
		EnemyRb2D = GetComponent<Rigidbody2D> ();
	}
	void Start () {
		isEnemyAttacking = false;
		isDead = false;
	}

	public void isDeadEnemy(bool deadEvent){
		isDead = deadEvent;
		animEnemy.SetBool ("EnemyDeads", deadEvent);
	}


	void Update () {
		if (player != null) {
			if (!isDead) {
				playerPosition = player.transform.position;
				if (!isEnemyAttacking) {
					if (gameObject.transform.position.x > playerPosition.x) {
						EnemyRb2D.velocity = new Vector2 (-speedEnemy, 0);
						gameObject.transform.rotation = Quaternion.Euler (0, 180, 0);
						animEnemy.Play ("Walk");
					} else if (gameObject.transform.position.x < playerPosition.x) {
						EnemyRb2D.velocity = new Vector2 (speedEnemy, 0);
						gameObject.transform.rotation = Quaternion.Euler (0, 0, 0);
						animEnemy.Play ("Walk");
					}
				}
				if (Mathf.Abs (gameObject.transform.position.x - playerPosition.x) < distToPlayer &&
					gameObject.transform.position.x - playerPosition.x > 0) {
					gameObject.transform.rotation = Quaternion.Euler (0, 180, 0);
					isEnemyAttacking = true;
				} else if (Mathf.Abs (gameObject.transform.position.x - playerPosition.x) < distToPlayer &&
					gameObject.transform.position.x - playerPosition.x < 0) {
					gameObject.transform.rotation = Quaternion.Euler (0, 0, 0);
					isEnemyAttacking = true;
				} else {
					isEnemyAttacking = false;
				}

				animEnemy.SetBool ("EnemyAttack", isEnemyAttacking);
			} else {
				Destroy (gameObject, 0.517f);
			}
		}
	}
}
