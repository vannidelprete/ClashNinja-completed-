using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Gestione della pozione rossa

public class RedPotion : MonoBehaviour {
	private PlayerHealth playerHealth;

	void Start () {
		playerHealth = GameObject.Find ("Player").GetComponent<PlayerHealth> ();
	}

	void OnTriggerEnter2D(Collider2D playerCollider){
		//Se il giocatore acquisisce la pozione verde i suoi HP aumentano di 1
		if (!playerCollider.isTrigger && playerCollider.CompareTag ("Player")) {
			playerHealth.UpHealth (1);
			Destroy (gameObject);
		}
	}
}
