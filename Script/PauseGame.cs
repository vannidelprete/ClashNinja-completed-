using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Gestione pausa del gioco

public class PauseGame : MonoBehaviour {
	private bool isPause;
	private GameObject textPause;

	void Awake () {
		isPause = false;
		textPause = GameObject.Find ("TextPause");
	}

	void Start() {
		textPause.SetActive (false);
	}

	void Update () {
		//pausa
		if (Input.GetButton ("Fire3") && !isPause) {
			isPause = true;
			textPause.SetActive (true);
			Time.timeScale = 0;
		}
		//ritorno al gioco
		if (Input.GetButton ("Fire2") && isPause) {
			isPause = false;
			textPause.SetActive (false);
			Time.timeScale = 1;
		}
	}
}
