using UnityEngine;
using System.Collections;

public class BossFace : MonoBehaviour {
	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Boss.purpleFace == true) {
			animator.SetTrigger ("lowHealth");

		}

		if (CountDown.reset == true) {
			animator.SetTrigger ("reset");

		}
	}
}
