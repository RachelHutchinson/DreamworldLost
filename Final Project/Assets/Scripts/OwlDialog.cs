using UnityEngine;
using System.Collections;

public class OwlDialog : MonoBehaviour {

	float dialogueCoolDown = 0;
	Dialogue OwlTrigger;
	int numberOfDialogLines = 0;
	bool didPlayerDieAtBoss;
	public static bool owlDialogue = false;


	// Use this for initialization
	void Start () 
	{
		GameObject DialogBox = GameObject.FindGameObjectWithTag ("Dialog Box");
		OwlTrigger = DialogBox.GetComponent <Dialogue> ();
	}
	
	// Update is called once per frame
	void Update () {
		//set this if statement the equivalent of losing all health/dying at the boss room
		//if ( == true) 
		{
		//	didPlayerDieAtBoss = true;
		}
		dialogueCoolDown -= Time.deltaTime;
	}

	void OnTriggerStay2D (Collider2D other) {

		if (other.CompareTag ("Player") && Input.GetKeyDown (KeyCode.Space)&& dialogueCoolDown <= 0)
		{
			Debug.Log ("let me working");


			if (didPlayerDieAtBoss == false) 
			{
				if (numberOfDialogLines == 0)
				{
					dialogueCoolDown = OwlTrigger.StartText ("Oh!");
					numberOfDialogLines = 1;
				}
				else if (numberOfDialogLines == 1)
				{
					dialogueCoolDown = OwlTrigger.StartText ("You have a awakened dear ******.");
					numberOfDialogLines = 2;
				}
			}
		}

	}
}