using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour {

	private Text dialogue;
	public string[] dialogueStrings;
	public float secondsBetweenCharacters = 0.1f; 


	void Start () {
		dialogue = GetComponent<Text>();
		dialogue.text = "";
	}
	
	public float StartText(string openingText) {
		StartCoroutine (DisplayString (openingText));
		return openingText.Length * secondsBetweenCharacters + 1;
		//above line returns how long full text takes to display
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
		//dialogue.text = "";
	}
}
