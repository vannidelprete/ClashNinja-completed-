using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {
	private MovePlayer movePlayer;

	void Start(){
		movePlayer = gameObject.GetComponentInParent<MovePlayer> ();
	}

	void OnTriggerEnter2D(Collider2D col){
		movePlayer.grounded = true;
	}
	void OnTriggerExit2D(Collider2D col){
		movePlayer.grounded = false;
	}
}
