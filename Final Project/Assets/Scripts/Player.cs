using UnityEngine;
using System.Collections;

public class Player : MovingObject {

	private Animator animator;
	GameObject player;
	public static Player instance = null;
	double coolDownTime = 0.4;
	double currentCoolDownTime = 0;
	public static bool bPlayer = false;
	public static bool gPlayer = false;

	public void Start ()
	{
		animator = GetComponent<Animator> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		base.Start ();
	}

	public void Update () 	
	{
		if (bPlayer == true) {
			animator.SetTrigger ("boyAnime");
			bPlayer = false;
		} 
		if (gPlayer == true) {
			Debug.Log ("hit");
			animator.SetTrigger ("girlAnime");
			gPlayer = false;
		}
		if (currentCoolDownTime > 0) 
		{
			currentCoolDownTime = currentCoolDownTime - Time.deltaTime;
			return;
		}

		int horizontal = 0;
		int vertical = 0;
		horizontal = (int)(Input.GetAxisRaw ("Horizontal"));
		vertical = (int)(Input.GetAxisRaw ("Vertical"));
		if (horizontal != 0) 
		{
			vertical = 0;
		}

		if (horizontal != 0 || vertical != 0) {
			AttemptMove (horizontal, vertical);
			currentCoolDownTime = coolDownTime;
		}
		if (vertical == 1) {
			animator.SetTrigger ("playerB");
		} 
		else if (vertical == -1) 
		{
			animator.SetTrigger("playerF");
		}
		else if (horizontal == 1) 
		{
			animator.SetTrigger("playerR");
		}
		else if (horizontal == -1) 
		{
			animator.SetTrigger("playerL");
		}
		else {
			animator.SetTrigger ("playerI");
		}
	}

	public void Walk(int xDir, int yDir) {
		RaycastHit2D rHit;
		Move (xDir, yDir, out rHit);
	}
		

	protected override void AttemptMove (int xDir, int yDir)
	{
		base.AttemptMove (xDir, yDir);
		RaycastHit2D hit;
	}

	private void Restart ()
	{
		Application.LoadLevel (Application.loadedLevel);
	}

}

