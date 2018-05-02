using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Gestione del movimento della Main Camera

public class MoveCamera : MonoBehaviour {
	private GameObject player;
	private float xPlayer;
	private float startWorld = 0f;
	private float endWorld = 127.8f;

	void Awake(){
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void Update () {
		if (player != null) {
			//segue il giocatore
			if (player.transform.position.x > startWorld && player.transform.position.x < endWorld) {
				xPlayer = player.transform.position.x;
				transform.position = new Vector3 (xPlayer, 0, -10);
			}
		}
	}
}
