using UnityEngine;
using System.Collections;

public class Player : MovingObject{

	public int wallDamage = 1;
	private Animator animator;
	GameObject player;

	double coolDownTime = 0.5;
	double currentCoolDownTime = 0;

	//protected override void Start () 
	protected void Start ()
	{
		animator = GetComponent<Animator> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		base.Start ();
	}

	// Update is called once per frame
	private void Update () 	
	{
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

	void OnTriggerEnter(Collider other)
	{	
		if (other.gameObject.CompareTag("Entrance"))
		{
			Debug.Log ("Teleporting!");
			player.transform.position = new Vector3 (10, 3, 0f);
		}
		return;
	}
}

