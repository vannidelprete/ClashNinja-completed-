using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordCollider : MonoBehaviour {
	private MovePlayer player;
	private Collider2D swordAttack;
	private EnemyBehaviour enemy;
	// Use this for initialization
	void Awake (){
		player = GetComponentInParent<MovePlayer> ();
		swordAttack = GetComponent<Collider2D> ();
	}
	void Start () {
		swordAttack.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (player.isAttacking) {
			swordAttack.enabled = true;
		} else {
			swordAttack.enabled = false;
		}
	}

	void OnTriggerEnter2D(Collider2D enemyCollider){
		if (!enemyCollider.isTrigger && enemyCollider.CompareTag("Enemy")) {
			enemyCollider.SendMessageUpwards ("isDeadEnemy", true);
		}
	}
}
