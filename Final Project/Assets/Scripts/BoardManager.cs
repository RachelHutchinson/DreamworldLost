using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour {

	public int innerColumns = 8;
	public int innerRows = 8;
	public int outerColumns = 24;
	public int outerrows = 24;
	public GameObject path;
	public GameObject [] innerTiles;
	public GameObject [] outerTiles;
	public GameObject [] innerWalls;
	public GameObject [] outerWalls;

	public class count
	{
		public int minimum;
		public int maximum;
		public Count (int min, int max)
		{
			minimum = min;
			maximum = max;
		}
	}
		

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
