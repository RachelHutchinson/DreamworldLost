using UnityEngine;
using System.Collections;

public class LibrarianDialog : MonoBehaviour {

	float dialogueCoolDown = 0;
	Dialogue LibrarianTrigger;
	int numberOfDialogLines = 0;
	bool didYouTalkToLibrarian;

	void Start () 
	{
		GameObject DialogBox = GameObject.FindGameObjectWithTag ("Dialog Box");
		LibrarianTrigger = DialogBox.GetComponent <Dialogue> ();
	}

		void OnTriggerStay2D (Collider2D other) {
		if (other.CompareTag ("Player") && Input.GetKeyDown (KeyCode.Space) && dialogueCoolDown <= 0) 
		{
			if (didYouTalkToLibrarian == false) 
			{	
				if (numberOfDialogLines == 0) 
				{
					dialogueCoolDown = LibrarianTrigger.StartText ("SSH!! Leave me to my work!");
					numberOfDialogLines = 1;
				}
			} 
			else 
			{
				didYouTalkToLibrarian = true;
				LibrarianTrigger.StartText ("");
				numberOfDialogLines = 0;
			}
		} 
		else if (didYouTalkToLibrarian == true) 
		{
			if (numberOfDialogLines == 0) 
			{
				dialogueCoolDown = LibrarianTrigger.StartText ("Shh! Look what you've done! You've ruined my concentration!");
				numberOfDialogLines = 1;
			}
		} 
		else 
		{
			LibrarianTrigger.StartText ("");
			numberOfDialogLines = 0;
		}

	}

	void OnTriggerExit2D (Collider2D other) 
	{
		LibrarianTrigger.StartText ("");
		numberOfDialogLines = 0;
	}
}
