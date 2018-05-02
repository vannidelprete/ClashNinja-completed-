using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets._3D4amb_LIB;

//Script per il rilevamento del miglior risultato

public class BestScore : MonoBehaviour {
	public SessionResult[] results;
	public PrefManager pm;


	void Update () {
		pm = GameObject.Find ("PrefManager").GetComponent<PrefManager> ();

		// acquisisce tutti i risultati delle sessioni del giocatore
		results = pm.LoadSResForActualPlayer ();

		//se ha fatto almeno una sessione, rileva il suo punteggio più alto
		//altrimenti il suo punteggio più alto è zero
		if (results != null) {
			foreach (SessionResult i in results) {
				if (i.Score > PlayerPrefs.GetInt ("BestScore", 0)) {
					PlayerPrefs.SetInt ("BestScore", i.Score);
				}
			}
		} else {
			PlayerPrefs.SetInt ("BestScore", 0);
		}

	}


	void OnApplicationQuit(){
		//salva il punteggio massimo all'uscita dal Main Menu
		PlayerPrefs.Save ();
	}
}
