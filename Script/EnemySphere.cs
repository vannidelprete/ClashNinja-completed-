using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script che gestisce il movimento e le collisioni degli incantesimi del mago

public class EnemySphere : MonoBehaviour {
	private float arrowSpeed = 3f;
	private Vector2 arrowDirection;
	private Vector2 arrowPosition;
	private Vector2 upToView;
	private Rigidbody2D rbSphere;

	void Awake(){
		//prendo il punto della visuale in alto a destra
		upToView = Camera.main.ViewportToWorldPoint (new Vector2(1, 1)); 
		rbSphere = gameObject.GetComponent<Rigidbody2D> ();
	}
		
	public void setArrowDirection(Vector2 direction){
		arrowDirection = direction.normalized;
	}
		
	void Update () {
		rbSphere.velocity = arrowDirection * arrowSpeed;
		if (transform.position.y > upToView.y) {
			Destroy (gameObject);
		}
	}
	void OnTriggerEnter2D(Collider2D other){
		if(!other.isTrigger && other.CompareTag("Player")){
			other.SendMessageUpwards ("Damage", 3);
		}
		Destroy (gameObject);
	}
}
