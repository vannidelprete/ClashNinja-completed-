using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Gestione della pozione verde

public class GreenPotion : MonoBehaviour {
	private PlayerHealth playerHealth;

	void Start () {
		playerHealth = GameObject.Find ("Player").GetComponent<PlayerHealth> ();
	}

	void OnTriggerEnter2D(Collider2D playerCollider){
		//Se il giocatore acquisisce la pozione verde i suoi HP aumentano di 3
		if (!playerCollider.isTrigger && playerCollider.CompareTag ("Player")) {
			playerHealth.UpHealth (3);
			Destroy (gameObject);
		}
	}
}
