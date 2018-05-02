using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Gestione della spada e acquisizione del punteggio

public class swordCollider : MonoBehaviour {
	private MovePlayer player;
	private Collider2D swordAttack;
	private EnemyBehaviour enemy;
	public int score;
	private TextMesh textScore;

	void Awake (){
		player = GetComponentInParent<MovePlayer> ();
		swordAttack = GetComponent<Collider2D> ();
		textScore = GameObject.Find ("Score").GetComponent<TextMesh> ();
	}

	void Start () {
		swordAttack.enabled = false;
		score = 0;
	}

	void Update () {
		textScore.text = +score + " pts";
		if (player.isAttacking) {
			//Se il giocatore attacca allora si attiva il collider della spada
			swordAttack.enabled = true;
		} else {
			swordAttack.enabled = false;
		}
	}

	void OnTriggerEnter2D(Collider2D enemyCollider){
		if (!enemyCollider.isTrigger && enemyCollider.CompareTag("Enemy")) {
			if(enemyCollider.GetComponent<EnemyBehaviour>() != null){
				if (enemyCollider.GetComponent<EnemyBehaviour> ().isDead == false) {
					enemyCollider.SendMessageUpwards ("isDeadEnemy", true);
					score++;
				}
			}
			if (enemyCollider.GetComponent<EnemyDragonBehaviour> () != null) {
				if (enemyCollider.GetComponent<EnemyDragonBehaviour> ().isDead == false) {
					enemyCollider.SendMessageUpwards ("isDeadEnemy", true);
					score++;
				}
			}
			if (enemyCollider.GetComponent<EnemyWizardBehaviour> () != null) {
				if (enemyCollider.GetComponent<EnemyWizardBehaviour> ().isDead == false) {
					enemyCollider.SendMessageUpwards ("isDeadEnemy", true);
					score++;
				}
			}
		}
	}
}
