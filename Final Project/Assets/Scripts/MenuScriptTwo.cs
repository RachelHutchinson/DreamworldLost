using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuScriptTwo : MonoBehaviour {

	public Canvas howtoMenu;
	public Button howtoText;
	public Button startText;
	public Button exitText;

	void Start () {
		howtoMenu = howtoMenu.GetComponent<Canvas> ();
		howtoText = howtoText.GetComponent<Button> ();

		howtoMenu.enabled = false;
	
	}
	
	public void HowtoPress ()
	{
		howtoMenu.enabled = true;
		startText.enabled = false;
		exitText.enabled = false;
		
	}

	public void BackPress ()
		
	{
		howtoMenu.enabled = false;
		startText.enabled = true;
		exitText.enabled = true;
	}
}
