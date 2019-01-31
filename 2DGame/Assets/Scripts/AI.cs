using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AI : MonoBehaviour {

	public Animator animator;
	public Transform player;
	public Transform self;
	public float distanceFromPlayer;
	public float sightRange;
	public float speed;
	public bool dead;
	public float delay;
	public float health;
	public float range;
	public Slider healthbar;
	private PlayerController playerScript;

	void Start () {
		player = GameObject.Find("Player").transform;
		playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
	}

	void Update () {
		if (playerScript.dead != true) {
			distanceFromPlayer = player.position.x - self.position.x;
			Physics2D.IgnoreCollision (player.gameObject.GetComponentInChildren<Collider2D> (), gameObject.GetComponentInChildren<Collider2D> ());
			if (Mathf.Abs (distanceFromPlayer) < sightRange && dead == false && Mathf.Abs (distanceFromPlayer) > range) {
				animator.SetBool ("Walk", true);
				if (distanceFromPlayer > 0 && self.rotation.y != 0) {
					transform.rotation = Quaternion.Euler (0, 0, 0);
				}
				if (distanceFromPlayer < 0 && self.rotation.y != -180) {
					transform.rotation = Quaternion.Euler (0, -180, 0);
				}
				transform.Translate (Vector2.right * Time.deltaTime * speed);
			} else {
				animator.SetBool ("Walk", false);
			}
			if (Mathf.Abs (distanceFromPlayer) <= range) {
				animator.SetTrigger ("Attack");

			}
			if (health <= 0) {
				animator.SetTrigger ("Death");
				Physics2D.IgnoreCollision (player.gameObject.GetComponentInChildren<Collider2D> (), gameObject.GetComponentInChildren<Collider2D> ());
				Destroy (gameObject, animator.GetCurrentAnimatorStateInfo (0).length + delay);
				dead = true;
			}
			healthbar.value = CalculateHealth ();
		}
	}

	public void takeDamage (int damage) {
		health -= damage;
	}

	float CalculateHealth () {
		return health / 50;
	}

}