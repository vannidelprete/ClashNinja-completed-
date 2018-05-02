using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaMovment : MonoBehaviour {
	private float speed = 0.1f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float x = Mathf.Repeat (Time.time * speed, 1);
		Vector2 offset = new Vector2 (x, 0);
		GetComponent<Renderer> ().sharedMaterial.SetTextureOffset ("_MainTex", offset);
	}
}
