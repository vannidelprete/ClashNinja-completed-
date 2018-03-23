using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {
	private Rigidbody2D rb2D;
	private Animator anim;
	public bool grounded;
	private float moveVelocity = 5f;
	private float jumpPower = 15f;
	private bool canJump;
	public bool isAttacking;
	private AudioSource jumpAudio;
	private AudioSource attackAudio;

	void Awake(){
		rb2D = gameObject.GetComponent<Rigidbody2D> ();
		anim = gameObject.GetComponent<Animator> ();
		jumpAudio = GameObject.Find ("jumpAudio").GetComponent<AudioSource> ();
		attackAudio = GameObject.Find ("attackAudio").GetComponent<AudioSource> ();
	}
	void Start(){
		canJump = true;
		isAttacking = false;
	}
	void Update(){
		if (grounded) {
			canJump = true;
		} else {
			canJump = false;
		}
		if (rb2D.velocity == Vector2.zero && !isAttacking) {
			anim.Play ("Idle");
		}
		if (Input.GetButton ("Horizontal") && Input.GetAxis ("Horizontal") > 0) {
			rb2D.transform.rotation = Quaternion.Euler (0, 0, 0);
			rb2D.velocity = Vector2.right * moveVelocity;
			if (grounded) {
				anim.Play ("Run");
			} else {
				anim.Play ("Jump");
			}
		}
		if (Input.GetButton ("Horizontal") && Input.GetAxis ("Horizontal") < 0) {
			rb2D.transform.rotation = Quaternion.Euler (0, 180, 0);
			rb2D.velocity = Vector2.left * moveVelocity;
			if (grounded) {
				anim.Play ("Run");
			} else {
				anim.Play ("Jump");
			}
		}
		if (Input.GetButtonDown ("Jump") && canJump) {
			rb2D.velocity = Vector2.up * jumpPower;
			anim.Play ("Jump");
			jumpAudio.Play ();
		}
		if (Input.GetButton ("Fire1") && !isAttacking) {
			anim.Play ("Attack");
			isAttacking = true;
			attackAudio.Play ();
		}
		if (Input.GetButtonUp ("Fire1")) {
			isAttacking = false;
		}
	}
}

