using UnityEngine;
using System.Collections;

public class PlayerT : MonoBehaviour {

	public float speed;
	private Rigidbody2D rb2d;
	private Animator animator;


	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		rb2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		rb2d.AddForce (movement * speed);
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			animator.SetTrigger ("playerB");
			return;
		} else if (Input.GetKeyUp (KeyCode.UpArrow)) {
			animator.SetTrigger ("playerI");
			return;
		}
		else if (Input.GetKeyDown (KeyCode.DownArrow)) 
		{
			animator.SetTrigger("playerF");
			return;
		}
		else if (Input.GetKeyUp (KeyCode.DownArrow)) {
			animator.SetTrigger ("playerI");
			return;
		}
		else if (Input.GetKeyDown (KeyCode.RightArrow)) 
		{
			animator.SetTrigger("playerR");
			return;
		}
		else if (Input.GetKeyUp (KeyCode.RightArrow)) {
			animator.SetTrigger ("playerI");
			return;
		}
		else if (Input.GetKeyDown (KeyCode.LeftArrow)) 
		{
			animator.SetTrigger("playerL");
			return;
		}
		else if (Input.GetKeyUp (KeyCode.LeftArrow)) {
			animator.SetTrigger ("playerI");
			return;
		}
	
	}
}
