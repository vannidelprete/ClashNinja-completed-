using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Script per il menu dei mondi

public class WorldButtonManager : MonoBehaviour {
	public Button world1;
	public Button world2;
	public Button world3;
	private int bestScore;
	private int pointsForWorld2 = 20;
	private int pointsForWorld3 = 30;

	void Awake () {
		bestScore = PlayerPrefs.GetInt ("BestScore");
	}

	void Update () {
		
		if (bestScore < pointsForWorld2) {
			world2.interactable = false;
			world2.GetComponent<Image> ().color = Color.black;
			world2.GetComponentInChildren<Text> ().enabled = false;
		} else {
			world2.interactable = true;
			world2.GetComponent<Image> ().color = Color.white;
			world2.GetComponentInChildren<Text> ().enabled = true;
		}

		if (bestScore < pointsForWorld3) {
			world3.interactable = false;
			world3.GetComponent<Image> ().color = Color.black;
			world3.GetComponentInChildren<Text> ().enabled = false;
		} else {
			world3.interactable = true;
			world3.GetComponent<Image> ().color = Color.white;
			world3.GetComponentInChildren<Text> ().enabled = true;
		}

		if (Input.GetButton ("Jump")) {
			SceneManager.LoadScene ("MainMenu");
			Destroy (GameObject.Find ("PrefManager"));
		}
	}

	public void LoadWorld1(){
		SceneManager.LoadScene ("PutOnVr1");
	}

	public void LoadWorld2(){
		SceneManager.LoadScene ("PutOnVr2");
	}

	public void LoadWorld3(){
		SceneManager.LoadScene ("PutOnVr3");
	}
}
