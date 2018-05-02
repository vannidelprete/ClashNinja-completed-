using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script dello spawning delle pozioni verdi e rosse

public class PotionSpawner : MonoBehaviour {
	private Vector3 positionRed;
	private Vector3 positionGreen;
	public GameObject redPotion;
	public GameObject greenPotion;
	private float timeRedMin = 50f;
	private float timeRedMax = 80f;
	private float timeGreenMin = 70f;
	private float timeGreenMax = 100f;
	private float startPosition = 10f;
	private float endPosition = 127.8f;

	void Start () {
		SpawnRedPotion ();
		SpawnGreenPotion ();
	}

	void SpawnRedPotion(){
		positionRed = new Vector3 (Random.Range(startPosition,endPosition), -3.18f, 0);
		Instantiate (redPotion, positionRed, Quaternion.identity);
		Invoke ("SpawnRedPotion", Random.Range (timeRedMin, timeRedMax));
	}

	void SpawnGreenPotion(){
		positionGreen = new Vector3 (Random.Range(startPosition,endPosition), -3.18f, 0);
		Instantiate (greenPotion, positionGreen, Quaternion.identity);
		Invoke ("SpawnGreenPotion", Random.Range (timeGreenMin, timeGreenMax));
	}
}
