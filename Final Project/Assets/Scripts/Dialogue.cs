using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour {

	private Text dialogue;
	public string[] dialogueStrings;
	public float secondsBetweenCharacters = 0.1f; 

	IEnumerator currentDialog;

	void Start () {
		dialogue = GetComponent<Text>();
		dialogue.text = "";
	}
	
	public float StartText(string openingText) {
		currentDialog = DisplayString (openingText);
		StartCoroutine (currentDialog);

		return openingText.Length * secondsBetweenCharacters + .5f;
		//above line returns how long full text takes to display
	}

	public void StopText() {
		StopCoroutine (currentDialog);
	}

	private IEnumerator DisplayString(string stringToDisplay)
	{
		int stringLength = stringToDisplay.Length;
		int currentCharacterIndex = 0;

		dialogue.text = "";

		while (currentCharacterIndex < stringLength) {
			dialogue.text += stringToDisplay [currentCharacterIndex];
			currentCharacterIndex++;

			if (currentCharacterIndex < stringLength) 
			{
				yield return new WaitForSeconds (secondsBetweenCharacters);

			} 
			else 
			{
				break;
			}
		}
	}
}
