using UnityEngine;
using System.Collections;

public class DialogTrigger : MonoBehaviour {

	Dialogue NurseTrigger;
	int numberOfDialogLines = 0;

	// Use this for initialization
	void Start () {
		GameObject DialogBox = GameObject.FindGameObjectWithTag ("Dialog Box");
		NurseTrigger = DialogBox.GetComponent <Dialogue> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D (Collider2D other) {
		//if space key is down
		if (other.CompareTag ("Player") && Input.GetKeyDown (KeyCode.Space)) 
		{
			if (numberOfDialogLines == 0)
			{
				NurseTrigger.StartText ("I'm a nurse!");
				numberOfDialogLines = 1;
			}
			else if (numberOfDialogLines == 0)
			{
				NurseTrigger.StartText ("You are not!");

				//make something appear
				numberOfDialogLines = 2;

				//set questCompleted to true
			}
			else
			{
				NurseTrigger.StartText ("");
				numberOfDialogLines = 0;
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
