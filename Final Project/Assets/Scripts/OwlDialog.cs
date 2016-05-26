using UnityEngine;
using System.Collections;

public class OwlDialog : MonoBehaviour {

	float dialogueCoolDown = 0;
	Dialogue OwlTrigger;
	int numberOfDialogLines = 0;
	public static bool didPlayerDieAtBoss;


	// Use this for initialization
	void Start () 
	{
		GameObject DialogBox = GameObject.FindGameObjectWithTag ("Dialog Box");
		OwlTrigger = DialogBox.GetComponent <Dialogue> ();
	}
	
	// Update is called once per frame
	void Update () {
		//set this if statement the equivalent of losing all health/dying at the boss room
		dialogueCoolDown -= Time.deltaTime;
	}

	void OnTriggerStay2D (Collider2D other) {

		if (other.CompareTag ("Player") && Input.GetKeyDown (KeyCode.Space)&& dialogueCoolDown <= 0)
		{
			if (didPlayerDieAtBoss == false) 
			{
				if (numberOfDialogLines == 0)
				{
					dialogueCoolDown = OwlTrigger.StartText ("Oh!");
					numberOfDialogLines = 1;
				}
				else if (numberOfDialogLines == 1)
				{
					dialogueCoolDown = OwlTrigger.StartText ("You have awakened dear ******.");
					numberOfDialogLines = 2;
				}
				else if (numberOfDialogLines == 2)
				{
					dialogueCoolDown = OwlTrigger.StartText ("We are in dire need of your help.");
					numberOfDialogLines = 3;
				}
				else if (numberOfDialogLines == 3)
				{
					dialogueCoolDown = OwlTrigger.StartText ("The Great Lord Angra Mainyu has taken over the domain.");
					numberOfDialogLines = 4;
				}
				else if (numberOfDialogLines == 4)
				{
					dialogueCoolDown = OwlTrigger.StartText ("You are the only one that can stop him.");
					numberOfDialogLines = 5;
				}
				else if (numberOfDialogLines == 5)
				{
					dialogueCoolDown = OwlTrigger.StartText ("Follow the path and meet your destiny!");
					numberOfDialogLines = 6;
				}
				else
				{
					OwlTrigger.StartText ("");
					numberOfDialogLines = 0;
				}
			}
			else if (didPlayerDieAtBoss == true) 
			{
				if (numberOfDialogLines == 0)
				{
					dialogueCoolDown = OwlTrigger.StartText ("What are you doing back here ******?");
					numberOfDialogLines = 1;
				}
				else if (numberOfDialogLines == 1)
				{
					dialogueCoolDown = OwlTrigger.StartText ("You died?");
					numberOfDialogLines = 2;
				}
				else if (numberOfDialogLines == 2)
				{
					dialogueCoolDown = OwlTrigger.StartText ("Well what did you expect, rampaging around like a mindless fool without knowing about the real world.");
					numberOfDialogLines = 3;
				}
				else if (numberOfDialogLines == 3)
				{
					dialogueCoolDown = OwlTrigger.StartText ("Let me make this clear: in five minutes we will all die");
					numberOfDialogLines = 4;
				}
				else if (numberOfDialogLines == 4)
				{
					dialogueCoolDown = OwlTrigger.StartText ("and then be born again");
					numberOfDialogLines = 5;
				}
				else if (numberOfDialogLines == 5)
				{
					dialogueCoolDown = OwlTrigger.StartText ("then die");
					numberOfDialogLines = 6;
				}
				else if (numberOfDialogLines == 6)
				{
					dialogueCoolDown = OwlTrigger.StartText ("then reborn.");
					numberOfDialogLines = 7;
				}
				else if (numberOfDialogLines == 7)
				{
					dialogueCoolDown = OwlTrigger.StartText ("You had the arrogance to think you knew about our lives here, and knew what you should have been doing.");
					numberOfDialogLines = 8;
				}
				else if (numberOfDialogLines == 8)
				{
					dialogueCoolDown = OwlTrigger.StartText ("What? I told you to follow the path? Well did you?");
					numberOfDialogLines = 9;
				}
				else if (numberOfDialogLines == 9)
				{
					dialogueCoolDown = OwlTrigger.StartText ("It doesn't matter anymore");
					numberOfDialogLines = 10;
				}
				else if (numberOfDialogLines == 10)
				{
					dialogueCoolDown = OwlTrigger.StartText ("Since you're such a little fool, I'll give you a gift.");
					numberOfDialogLines = 11;
				}
				else if (numberOfDialogLines == 11)
				{
					dialogueCoolDown = OwlTrigger.StartText ("See that box next to me with a clock on it? Why don't you go over there and press space.");
					numberOfDialogLines = 12;
				}
				else if (numberOfDialogLines == 12)
				{
					dialogueCoolDown = OwlTrigger.StartText ("That way you'll have a little warning before you die again.");
					numberOfDialogLines = 13;
				}
				else
				{
					OwlTrigger.StartText ("");
					numberOfDialogLines = 0;
				}
			}
			else 
			{
				if (numberOfDialogLines == 0)
				{
					dialogueCoolDown = OwlTrigger.StartText ("I'll be amazed if you manage to accomplish anything.");
					numberOfDialogLines = 1;
				}
				else
				{
					OwlTrigger.StartText ("");
					numberOfDialogLines = 0;
				}
			}
		}
	}
	void OnTriggerExit2D (Collider2D other) 
	{
		OwlTrigger.StartText ("");
		numberOfDialogLines = 0;
	}
	//Trigger exit
}