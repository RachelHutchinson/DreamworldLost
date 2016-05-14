using UnityEngine;
using System.Collections;

public class Player : MovingObject {

	public int wallDamage = 1;
	private Animator animator;
	GameObject player;
	public static Player instance = null;
	double coolDownTime = 0.3;
	double currentCoolDownTime = 0;
	public static bool bPlayer = false;
	//public static bool gPlayer = false;

	//protected override void Start () 
	public void Start ()
	{
		animator = GetComponent<Animator> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		base.Start ();
	}

	// Update is called once per frame
	public void Update () 	
	{
		if (bPlayer == true) {
			Debug.Log ("true");
			animator.SetTrigger ("boyAnime");
			bPlayer = false;
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
			AttemptMove <Wall> (horizontal, vertical);
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
		

	protected override void AttemptMove <T> (int xDir, int yDir)
	{
		base.AttemptMove <T> (xDir, yDir);
		RaycastHit2D hit;
		/*if (AttemptMove (xDir, yDir, outhit))
			CheckIfGameOver ();
		GameManager.instance.playersTurn = false;*/
	}

	protected override void OnCantMove <T> (T component)
	{
		Wall hitWall = component as Wall;
		hitWall.DamageWall (wallDamage);
	}

	private void Restart ()
	{
		Application.LoadLevel (Application.loadedLevel);
	}

}

