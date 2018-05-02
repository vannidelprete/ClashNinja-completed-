using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Rilevamento se il giocatore è a terra o in salto

public class GroundCheck : MonoBehaviour {
	private MovePlayer movePlayer;

	void Start(){
		movePlayer = gameObject.GetComponentInParent<MovePlayer> ();
	}

	void OnTriggerStay2D(Collider2D col){
		movePlayer.grounded = true;
	}
	void OnTriggerExit2D(Collider2D col){
		movePlayer.grounded = false;
	}
}
