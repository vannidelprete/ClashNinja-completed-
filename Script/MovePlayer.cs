using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Gestione del movimento del giocatore

public class MovePlayer : MonoBehaviour {
	private Rigidbody2D rb2D;
	private Animator anim;
	public bool grounded;
	private float maxVelocity = 4f;
	private float moveVelocity = 50f;
	private float jumpPower = 600f;
	public bool isAttacking;
	public bool isDead;
	private AudioSource jumpAudio;
	private AudioSource attackAudio;

	void Awake(){
		rb2D = gameObject.GetComponent<Rigidbody2D> ();
		anim = gameObject.GetComponent<Animator> ();
		jumpAudio = GameObject.Find ("jumpAudio").GetComponent<AudioSource> ();
		attackAudio = GameObject.Find ("attackAudio").GetComponent<AudioSource> ();
	}

	void Start(){
		isAttacking = false;
		isDead = false;
	}

	void FixedUpdate(){
		float xInput = Input.GetAxis ("Horizontal");
		if (!isDead) {
			rb2D.AddForce (Vector2.right * moveVelocity * xInput);

			if (rb2D.velocity.x > maxVelocity) {
				rb2D.velocity = new Vector2 (maxVelocity, rb2D.velocity.y);
			}

			if (rb2D.velocity.x < -maxVelocity) {
				rb2D.velocity = new Vector2 (-maxVelocity, rb2D.velocity.y);
			}

			if (xInput == 0) {
				rb2D.velocity = new Vector2 (0, 0);
			}
		}
	}
		
	void Update () {
		//Gestione delle clip del mecanim
		anim.SetFloat ("Speed", Mathf.Abs (Input.GetAxis ("Horizontal")));
		anim.SetBool ("Grounded", grounded);
		anim.SetBool ("IsAttacking", isAttacking);
		anim.SetBool ("IsDead", isDead);
		if (!isDead) {
			//rotazione del giocatore
			if (Input.GetAxis ("Horizontal") > 0.1f) {
				transform.localScale = new Vector3 (1, 1, 1);
			}
			if (Input.GetAxis ("Horizontal") < -0.1f) {
				transform.localScale = new Vector3 (-1, 1, 1);
			}
			//salto
			if (Input.GetButtonDown ("Jump") && grounded) {
				rb2D.AddForce (Vector2.up * jumpPower);
				jumpAudio.Play ();
			}
			//attacco
			if (Input.GetButton ("Fire1")) {
				isAttacking = true;
				attackAudio.Play ();
			} else {
				isAttacking = false;
			}
		}
	}
}