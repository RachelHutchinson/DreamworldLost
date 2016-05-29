using UnityEngine;
using System.Collections;

public class LibrarianDialog : MonoBehaviour {

	float dialogueCoolDown = 0;
	Dialogue LibrarianTrigger;
	int numberOfDialogLines = 0;
	bool didYouTalkToLibrarian;
	public static bool silenceInTheLibrary;
	public static bool setForPick;


	void Start () 
	{
		GameObject DialogBox = GameObject.FindGameObjectWithTag ("Dialog Box");
		LibrarianTrigger = DialogBox.GetComponent <Dialogue> ();
		setForPick = false;
		silenceInTheLibrary = false;
	}

	void Update () 
	{
	dialogueCoolDown -= Time.deltaTime;
	}

	void OnTriggerStay2D (Collider2D other) {
		if (other.CompareTag ("Player") && Input.GetKeyDown (KeyCode.Space) && dialogueCoolDown <= 0) 
		{
			if (silenceInTheLibrary == true)
			{
				if (numberOfDialogLines == 0) 
				{
					dialogueCoolDown = LibrarianTrigger.StartText ("If you are ever in a bind just press 'H' and let the book gods guide you.");
					numberOfDialogLines = 1;
				}
				else 
				{
					LibrarianTrigger.StartText ("");
					numberOfDialogLines = 0;
				}
			} 

			if (didYouTalkToLibrarian == false) 
			{	
				if (numberOfDialogLines == 0) 
				{
					setForPick = true;
					dialogueCoolDown = LibrarianTrigger.StartText ("SSH!! Leave me to my work!");
					numberOfDialogLines = 1;
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
					setForPick = false;
				}
				else 
				{
					LibrarianTrigger.StartText ("");
					numberOfDialogLines = 0;
				}
		 	}
		}

	}

	void OnTriggerExit2D (Collider2D other) 
	{
		LibrarianTrigger.StartText ("");
		numberOfDialogLines = 0;
	}
}
