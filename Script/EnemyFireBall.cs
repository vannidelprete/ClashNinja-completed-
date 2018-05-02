using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireBall : MonoBehaviour {
	private float arrowSpeed = 7f;
	private Vector2 arrowDirection;
	private Vector2 arrowPosition;
	private Vector3 arrowRotation;
	private Vector2 upToView;
	private Rigidbody2D rbFireBall;

	void Awake(){
		//prendo il punto della visuale in alto a destra
		upToView = Camera.main.ViewportToWorldPoint (new Vector2(1, 1));
		rbFireBall = gameObject.GetComponent<Rigidbody2D> ();
	}
		
	public void setArrowDirection(Vector2 direction){
		arrowDirection = direction.normalized;
		arrowRotation = new Vector3 (0, 0, Mathf.Atan2 (direction.x, -direction.y)*Mathf.Rad2Deg);
	}


	void Update () {
		transform.rotation = Quaternion.Euler (arrowRotation);
		rbFireBall.velocity = arrowDirection * arrowSpeed;
		if (transform.position.y > upToView.y) {
			Destroy (gameObject);
		}
	}
	void OnTriggerEnter2D(Collider2D other){
		if(!other.isTrigger && other.CompareTag("Player")){
			other.SendMessageUpwards ("Damage", 2);
		}
		Destroy (gameObject);
	}
}
