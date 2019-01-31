using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDamage : MonoBehaviour {

	public int damage;
	public Animator animator;

	void OnTriggerEnter2D (Collider2D suspect) {
		if (suspect.gameObject.tag == "Player" && animator.GetCurrentAnimatorStateInfo(0).IsName("Skeleton1_Attack")) {
			suspect.gameObject.GetComponentInParent<PlayerController> ().damagePlayer (damage);
		}
	}
}
