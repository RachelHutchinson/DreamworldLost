using UnityEngine;
using System.Collections;

public class DialogTrigger : MonoBehaviour {

	float dialogueCoolDown = 0;
	Dialogue NurseTrigger;
	int numberOfDialogLines = 0;
	bool isNurseQuestComplete;
	bool pickUpReceived;
	public static bool nurseDialogue = false;

	void Start () {
		GameObject DialogBox = GameObject.FindGameObjectWithTag ("Dialog Box");
		NurseTrigger = DialogBox.GetComponent <Dialogue> ();
	}
	
	void Update () {
		if (Flower.flowerBool == true) 
		{
			isNurseQuestComplete = true;
		}
		dialogueCoolDown -= Time.deltaTime;
	}

	void OnTriggerStay2D (Collider2D other) {
		//if space key is down
		if (other.CompareTag ("Player") && Input.GetKeyDown (KeyCode.Space)) 
		{
			if (dialogueCoolDown > 0)
			{
				NurseTrigger.FinishText();
				return;
			}
			if (isNurseQuestComplete == false) {
				if (numberOfDialogLines == 0)
				{
					dialogueCoolDown = NurseTrigger.StartText ("Hello, I'm the Nurse!");
					numberOfDialogLines = 1;
				}
				else if (numberOfDialogLines == 1)
				{
					dialogueCoolDown = NurseTrigger.StartText ("Could you please help me?");
					numberOfDialogLines = 2;
				}
				else if (numberOfDialogLines == 2)
				{
					dialogueCoolDown = NurseTrigger.StartText ("Please help me find a flower for my medicine.");
					nurseDialogue = true;
					numberOfDialogLines = 3;
				
				}
				else if (numberOfDialogLines == 3)
				{
					dialogueCoolDown = NurseTrigger.StartText ("Go find it, and then come speak to me.");
					nurseDialogue = true;
					numberOfDialogLines = 4;
					
				}

				else
				{
					NurseTrigger.StartText ("");
					numberOfDialogLines = 0;
				}
			
			}
			else if (pickUpReceived ==false) 
			{
				if (numberOfDialogLines == 0)
				{
					dialogueCoolDown = NurseTrigger.StartText ("Oh, thank you!");
					numberOfDialogLines = 1;
				}
				else if (numberOfDialogLines == 1)
				{
					dialogueCoolDown = NurseTrigger.StartText ("You did great!");
					numberOfDialogLines = 2;
				}
				else if (numberOfDialogLines == 2)
				{
					dialogueCoolDown = NurseTrigger.StartText ("Lord Angra Mainyu had taken all my healing medicine away!");
					numberOfDialogLines = 3;
				}
				else if (numberOfDialogLines == 3)
				{
					dialogueCoolDown = NurseTrigger.StartText ("But with this, I can make new medicine to help people!");
					numberOfDialogLines = 4;
				}
				else if (numberOfDialogLines == 4)
				{
					dialogueCoolDown = NurseTrigger.StartText ("Thank you for your help.");
					numberOfDialogLines = 5;
				}
				else if (numberOfDialogLines == 5)
				{
					dialogueCoolDown = NurseTrigger.StartText ("Please take this as a reward.");
					numberOfDialogLines = 6;
				}
				else
				{
					GameManager.hPick = true;
					pickUpReceived = true;
					NurseTrigger.StartText ("");
					numberOfDialogLines = 0;
				}
			}
			else 
			{
				if (numberOfDialogLines == 0)
				{
					dialogueCoolDown = NurseTrigger.StartText ("Take care, child!");
					numberOfDialogLines = 1;
				}
				else
				{
					NurseTrigger.StartText ("");
					numberOfDialogLines = 0;
				}
			}
		}

	}

	void OnTriggerExit2D (Collider2D other) 
	{
		NurseTrigger.StopText();
		NurseTrigger.StartText ("");
		numberOfDialogLines = 0;
	}


}

//set bool for quest vs completed dialog
//reward player for fulfilling a quest with pickup
