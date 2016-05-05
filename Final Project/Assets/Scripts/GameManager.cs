using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour {

	private BoardManager boardScript;
	public AudioClip roomSound1;
	public AudioClip fieldSound1;


	private int level = 1;

	// Use this for initialization
	void Start () {
		boardScript = GetComponent<BoardManager> ();
		InitGame ();
	}

	void InitGame ()
	{
		boardScript.SetupScene(level);
	}

	// Update is called once per frame
	void Update () {
	}
}
