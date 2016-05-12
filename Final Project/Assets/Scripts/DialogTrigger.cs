using UnityEngine;
using System.Collections;

public class DialogTrigger : MonoBehaviour {

	float dialogueCoolDown = 0;
	Dialogue NurseTrigger;
	int numberOfDialogLines = 0;
	bool isNurseQuestComplete;
	public static bool nurseDialogue = false;

	// Use this for initialization
	void Start () {
		GameObject DialogBox = GameObject.FindGameObjectWithTag ("Dialog Box");
		NurseTrigger = DialogBox.GetComponent <Dialogue> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Flower.flowerBool == true) 
		{
			isNurseQuestComplete = true;
		}
		dialogueCoolDown -= Time.deltaTime;
	}

	void OnTriggerStay2D (Collider2D other) {
		//if space key is down
		if (other.CompareTag ("Player") && Input.GetKeyDown (KeyCode.Space)&& dialogueCoolDown <= 0) 
		{
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
					dialogueCoolDown = NurseTrigger.StartText ("Please press 'A' and then come speak to me.");
					nurseDialogue = true;
				
					//make something appear
					numberOfDialogLines = 3;
				
					//set questCompleted to true
				}

				else
				{
					NurseTrigger.StartText ("");
					numberOfDialogLines = 0;
				}
			
			}
			else 
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
					dialogueCoolDown = NurseTrigger.StartText ("Please take this as a reward.");
					GameManager.hPick = true;
					
					//send pickup to room for future use
					numberOfDialogLines = 3;
					
					//set questCompleted to true, unable to redo this quest after doing it once
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
		NurseTrigger.StartText ("");
		numberOfDialogLines = 0;
	}


}

//set bool for quest vs completed dialog
//reward player for fulfilling a quest with pickup
