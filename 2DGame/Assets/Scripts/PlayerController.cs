using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public Animator animator;
	public Animation animation;
	public float speed = 10f; //speed of character
	public bool stab;
	public float stabSpeed;
	public bool slash;
	public bool roll;
	public int playerHealth = 100;
	public Slider healthbar;
	Collider2D Col;
	public float isGroundedRayLength = 0.1f;
	public bool dead = false;
	public GameObject sword;

	void Start () {
		animation = GetComponent<Animation>();
		Col = GetComponentInChildren<Collider2D>();
		sword = GameObject.Find("sword");
	}

	//Update is called once per frame
	void Update () {
		if (sword.activeInHierarchy) { //checks if sword is active
			animator.SetBool ("HasSword", true);
		} else {
			animator.SetBool ("HasSword", false);
		}
		healthbar.value = playerHealth / 100f;

		if (dead == false) {
			if (animator.GetBool ("HasSword") == true) { //checks if sword is equipped
				if (Input.GetKeyDown (KeyCode.X)) {
					stab = true;
				}
				if (Input.GetKeyDown (KeyCode.C)) {
					slash = true;
				}
				if (Input.GetKeyDown (KeyCode.V)) {
					//roll = true;
				}
			}

			if (Input.GetAxis ("Horizontal") != 0) { // checks if player presses left or right
					animator.SetBool ("Walking", true);
					if (Input.GetAxis ("Horizontal") < 0) {
						transform.rotation = Quaternion.Euler (0, 0, 0); // if left key is pressed character moves left
					}
					if (Input.GetAxis ("Horizontal") > 0) {
						transform.rotation = Quaternion.Euler (0, 180, 0); // if right key is pressed, character is flipped
					}

					transform.Translate (Vector2.left * Time.deltaTime * speed);
						
					if (Input.GetKeyDown(KeyCode.LeftShift) == true) {
						transform.Translate(Vector3.left * Time.deltaTime * speed * 1.5f);
					}
				} else {
					animator.SetBool ("Walking", false);
				}

			if (stab) {
				animator.SetTrigger ("Stab");
				animator.SetBool ("Walking", false);
				transform.Translate (Vector2.left * Time.deltaTime * stabSpeed);
				stab = false;
			}
			if (slash) {
				animator.SetTrigger ("Slash");
				animator.SetBool ("Walking", false);
				slash = false;
			}
			if (roll) {
				GetComponent<Rigidbody2D>().gravityScale = 0;
				Col.enabled = !Col.enabled;
				animator.SetTrigger ("Roll");
				roll = false;
			}
			if (!animator.GetCurrentAnimatorStateInfo(0).Equals("Player_Roll")) {
				GetComponent<Rigidbody2D>().gravityScale = 1;
				Col.enabled = Col.enabled;
			}
		}
		if (playerHealth <= 0) { // kills player when health is below/equal to 0
			dead = true;
			animator.SetBool("Dead", true);
			animator.SetBool ("Walking", false);
		}	
	}
	public void damagePlayer (int damage) {
		playerHealth = playerHealth - damage;
	}
}