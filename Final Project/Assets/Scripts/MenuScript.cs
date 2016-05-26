using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : MonoBehaviour {

	public Canvas quitMenu;
	public Button startText;
	public Button exitText;

	// Use this for initialization
	void Start () {
		quitMenu = quitMenu.GetComponent<Canvas> ();
		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();
		//dissable the quit menu
		quitMenu.enabled = false;

	
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




}
