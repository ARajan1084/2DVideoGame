using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour {
	
	public int damage;
	public Animator animator;

	void OnTriggerEnter2D (Collider2D suspect) {
		if (suspect.gameObject.tag == "Enemy" && !animator.GetBool("Walking") && !animator.GetCurrentAnimatorStateInfo(0).IsName("Player_Idle")) {			
			if (animator.GetCurrentAnimatorStateInfo(0).IsName("Player_Slash")) {
				suspect.transform.gameObject.GetComponentInParent<AI> ().takeDamage (2 * damage);
			} else {
				suspect.transform.gameObject.GetComponentInParent<AI> ().takeDamage (damage);
			}
		}
	}
}
