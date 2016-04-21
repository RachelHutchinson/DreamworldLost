using UnityEngine;
using System.Collections;

public class Player : MovingObject {


	private Animator animator;

	protected override void Start () 
	{
		animator = GetComponent<Animator> ();
		base.Start ();
	}
	
	// Update is called once per frame
	private void Update () 
	{
		//if (!GameManager.instance.playersTurn) return;
		int horizontal = 0;
		int vertical = 0;
		horizontal = (int)(Input.GetAxisRaw ("Horizontal"));
		vertical = (int)(Input.GetAxisRaw ("Vertical"));
		if (horizontal != 0) 
		{
			vertical = 0;
		}
		if (Input.GetKeyDown (KeyCode.UpArrow)) 
		{
			animator.SetTrigger("playerB");
			return;
		}
		if (Input.GetKeyDown (KeyCode.DownArrow)) 
		{
			animator.SetTrigger("playerF");
			return;
		}
		if (Input.GetKeyDown (KeyCode.RightArrow)) 
		{
			animator.SetTrigger("playerR");
			return;
		}
		if (Input.GetKeyDown (KeyCode.LeftArrow)) 
		{
			animator.SetTrigger("playerL");
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

	/*protected override void OnCantMove <T> (T component)
	{
	}*/

	private void Restart ()
	{
		Application.LoadLevel (Application.loadedLevel);
	}
}

