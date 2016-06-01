using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : MonoBehaviour {

	public Canvas quitMenu;
	public Button startText;
	public Button exitText;
	public Canvas howtoMenu;

	void Start () {
		quitMenu = quitMenu.GetComponent<Canvas> ();
		//howtoMenu = howtoMenu.GetComponent<Canvas> ();
		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();
		//howtoText = howtoText.GetComponent<Button> ();


		//dissable the quit menu
		quitMenu.enabled = false;
		//howtoMenu.enabled = false;

	
	}

	public void StartLevel ()
	{
		//load first level when click play
		Application.LoadLevel (1);
	}

	public void ExitGame ()
	{
		//exit menu yes - quit game
		Application.Quit ();
	}

	public void ExitPress ()
	{
		//display quit menu
		//dissable start and exit button 
	
		quitMenu.enabled = true;
		startText.enabled = false;
		exitText.enabled = false;
	}


	public void NoPress ()
	{
		// dissable quit menu

		quitMenu.enabled = false;
		startText.enabled = true;
		exitText.enabled = true;
	}
	public void HowtoPress ()
	{
		howtoMenu.enabled = true;
		startText.enabled = false;
		exitText.enabled = false;
		
	}

}
