using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArrow : MonoBehaviour {
	private float arrowSpeed = 5f;
	private Vector2 arrowDirection;
	private Vector2 arrowPosition;
	private Vector3 arrowRotation;
	private Vector2 upToView;
	// Use this for initialization
	void Awake(){
		upToView = Camera.main.ViewportToWorldPoint (new Vector2(1, 1)); //prendo il punto della visuale in alto a destra
	}
	void Start () {
	}
	public void setArrowDirection(Vector2 direction){
		arrowDirection = direction.normalized;
		arrowRotation = new Vector3 (0, 0, Mathf.Atan2 (direction.x, -direction.y)*Mathf.Rad2Deg);
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.Euler (arrowRotation);
		gameObject.GetComponent<Rigidbody2D> ().velocity = arrowDirection * arrowSpeed;
		if (transform.position.y > upToView.y) {
			Destroy (gameObject);
		}
	}
	void OnCollisionEnter2D(Collision2D coll){
		Destroy (gameObject);
	}
}
