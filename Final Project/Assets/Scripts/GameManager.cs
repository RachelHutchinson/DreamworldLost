using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour {

	private BoardManager boardScript;
	public int playerHealth;



	private int level = 1;

	// Use this for initialization
	public void Start () {
		boardScript = GetComponent<BoardManager> ();
		InitGame ();
	}

	public void InitGame ()
	{
		boardScript.SetupScene(level);
	}

	// Update is called once per frame
	void Update () {
		Boss score = GetComponent <Boss> ();
		playerHealth = score.playerHealth; 
		}
}
