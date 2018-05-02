using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Gestione degli HP del giocatore

public class PlayerHealth : MonoBehaviour {
	private int health = 10;
	private MovePlayer movePlayer;
	public Sprite[] barSprite;
	private SpriteRenderer lifeBar;
	private swordCollider swordCollider;
	private SessionManager sessionManager;

	void Awake () {
		sessionManager = GameObject.Find ("SessionManager").GetComponent<SessionManager> ();
		movePlayer = GetComponent<MovePlayer> ();
		lifeBar = GameObject.Find ("LifeBar").GetComponent<SpriteRenderer> ();
	}

	//Se viene colpito dall'attacco del nemico diminuisce gli HP
	public void Damage(int dmg){
		if (health != 0 && health-dmg >= 0) {
			health = health - dmg;
		}else{
			health = 0;
		}
	}

	//Se acquisisce le pozioni aumenta gli HP
	public void UpHealth (int up) {
		if (health + up < 10) {
			health += up;
		} else {
			health = 10;
		}
	}

	void Update () {
		if (health != 0) {
			//Gestione della barra salute
			lifeBar.sprite = barSprite [health - 1];
		}
		if (health == 0) {
			//Se gli HP finiscono il giocatore è sconfitto
			//Acquisizione del punteggio
			swordCollider = GameObject.Find ("SwordCollider").GetComponent<swordCollider> ();
			sessionManager.SetScore (swordCollider.score);
			movePlayer.isDead = true;
			Destroy (gameObject, 3f);
		}
	}

	void OnDestroy(){
		sessionManager.SaveSession ();
		SceneManager.LoadScene ("MainMenu");
	}
}
