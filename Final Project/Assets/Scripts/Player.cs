using UnityEngine;
using System.Collections;

public class Player : MovingObject{

	public int wallDamage = 1;
	private Animator animator;
	GameObject player;

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
		}
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
			player.transform.position = new Vector3 (3f, 0f, 0f);
		}
		return;
	}
}

