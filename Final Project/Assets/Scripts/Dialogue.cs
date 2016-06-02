using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour {

	private Text dialogue;
	string dialogueString;
	public float secondsBetweenCharacters = 0.1f; 

	IEnumerator currentDialog;

	void Start () {
		dialogue = GetComponent<Text>();
		dialogue.text = "";
	}
	
	public float StartText(string openingText) {
		dialogueString = openingText;
		currentDialog = DisplayString (openingText);
		StartCoroutine (currentDialog);

		return openingText.Length * secondsBetweenCharacters + .1f;
		//above line returns how long full text takes to display
	}

	public void FinishText() {
		StopCoroutine (currentDialog);
		dialogue.text = dialogueString; 
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
