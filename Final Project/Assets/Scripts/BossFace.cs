using UnityEngine;
using System.Collections;

public class BossFace : MonoBehaviour {
	private Animator animator;

	void Start () {
		animator = GetComponent<Animator> ();
	
	}
	
	void Update () {
		if (Boss.purpleFace == true) {
			animator.SetTrigger ("lowHealth");

		}

		if (CountDown.reset == true) {
			animator.SetTrigger ("reset");

		}
	}
}
