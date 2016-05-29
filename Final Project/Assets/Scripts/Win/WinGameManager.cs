using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class WinGameManager : MonoBehaviour {

	private WinBoardManager boardScript;

	private int level = 1;

	// Use this for initialization
	public void Start () {
		boardScript = GetComponent<WinBoardManager> ();
		InitGame ();
	}

	public void InitGame ()
	{
		boardScript.SetupScene(level);
	}

	// Update is called once per frame
	void Update () {
	}
}