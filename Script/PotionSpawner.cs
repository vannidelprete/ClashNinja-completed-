using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionSpawner : MonoBehaviour {
	private Vector3 positionRed;
	private Vector3 positionGreen;
	public GameObject redPotion;
	public GameObject greenPotion;
	private float timeRedMin = 10f;
	private float timeRedMax = 20f;
	private float timeGreenMin = 30f;
	private float timeGreenMax = 60f;
	// Use this for initialization

	void Start () {
		SpawnRedPotion ();
		SpawnGreenPotion ();
	}

	void SpawnRedPotion(){
		positionRed = new Vector3 (Random.Range(10f,127.8f), -3.18f, 0);
		Instantiate (redPotion, positionRed, Quaternion.identity);
		Invoke ("SpawnRedPotion", Random.Range (timeRedMin, timeRedMax));
	}

	void SpawnGreenPotion(){
		positionGreen = new Vector3 (Random.Range(10f,127.8f), -3.18f, 0);
		Instantiate (greenPotion, positionGreen, Quaternion.identity);
		Invoke ("SpawnGreenPotion", Random.Range (timeGreenMin, timeGreenMax));
	}
}
