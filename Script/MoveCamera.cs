using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {
	private GameObject player;
	private float xPlayer;
	// Use this for initialization
	void Awake(){
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (player.transform.position.x > 0) {
			xPlayer = player.transform.position.x;
			transform.position = new Vector3 (xPlayer,0,-10);
		}
	}
}
