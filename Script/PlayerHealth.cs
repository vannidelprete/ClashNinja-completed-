using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {
	private int health = 10;
	private Animator animPlayer;
	private MovePlayer movePlayer;
	public Sprite[] barSprite;
	private SpriteRenderer lifeBar;

	// Use this for initialization
	void Awake () {
		animPlayer = GetComponent<Animator> ();
		movePlayer = GetComponent<MovePlayer> ();
		lifeBar = GameObject.Find ("LifeBar").GetComponent<SpriteRenderer> ();
	}

	public void Damage(int dmg){
		if (health != 0) {
			health = health - dmg;
			animPlayer.Play ("Hurt");
		}
	}

	void Update () {
		if (health != 0) {
			lifeBar.sprite = barSprite [health - 1];
		}
		if (health == 0) {
			movePlayer.isDead = true;
			animPlayer.Play ("Death");
			Destroy (gameObject,3f);
			}
		}
}
