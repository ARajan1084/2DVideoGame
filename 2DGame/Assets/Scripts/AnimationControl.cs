using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour {

	public static int animationID;
	public Animator animator;
	public float animatorSpeed;	

	void Update() {
		animationID = Animator.StringToHash("Walking");
		bool isWalking = animator.GetBool(animationID);

		if (isWalking == true) {
			GetComponent<Animator> ().speed = animatorSpeed;

			if (Input.GetKey(KeyCode.LeftShift) == true) {
				GetComponent<Animator> ().speed = animatorSpeed * 2;
			}

		} else {
			GetComponent<Animator> ().speed = 1f;
		}
		//OnAnimatorMove ();
	}
	/*
	void OnAnimatorMove(){
		transform.parent.position += animator.deltaPosition * Time.deltaTime;
	}
	*/
}
