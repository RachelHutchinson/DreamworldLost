using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour {

	public int innerColumns = 10;
	public int innerRows = 10;
	public int outerColumns = 60;
	public int outerRows = 50;
	public GameObject path;
	public GameObject [] innerTiles;
	public GameObject [] outerTiles;
	public GameObject [] innerWalls;
	public GameObject [] outerWalls;

	private Transform boardHolder;
	private List <Vector3> gridPositions = new List <Vector3> ();


	void BoardSetup()
	{
		boardHolder = new GameObject ("Board").transform;
		for (int x = -1; x < innerColumns; x++) {
			for (int y = -1; y < innerRows; y++) {
				GameObject toInstantiate = innerTiles [Random.Range (0, innerTiles.Length)];
				if (x == -1 || x == innerColumns || y == -1|| y == innerRows)
					toInstantiate = innerWalls [Random.Range (0, innerWalls.Length)];
				GameObject instance =
					Instantiate (toInstantiate, new Vector3 (x, y, 0f), Quaternion.identity) as GameObject;
			}
		}
		for (int x = 8; x < outerColumns + 1; x++) {
			for (int y = -20; y < outerRows + 1; y++) {
				GameObject toInstantiate = outerTiles [Random.Range (0, outerTiles.Length)];
				if (x == 8|| x == outerColumns || y == -20 || y == outerRows)
					toInstantiate = outerWalls [Random.Range (0, outerWalls.Length)];
				GameObject instance =
					Instantiate (toInstantiate, new Vector3 (x, y, 0f), Quaternion.identity) as GameObject;
				instance.transform.SetParent (boardHolder);
			}
		}
	}

		

 public class Count
	{
		public int minimum;
		public int maximum;
		public Count (int min, int max)
		{
			minimum=min;
			maximum=max;
		}
	}

	Vector3 RandomPosition ()
	{
		int randomIndex = Random.Range (0, gridPositions.Count);
		Vector3 randomPosition = gridPositions [randomIndex];
		gridPositions.RemoveAt(randomIndex);
		return randomPosition;
	}
		
	void LayoutObjectAtRandom (GameObject [] outerTileArray, int minimum, int maximum)
	{
		int objectCount = Random.Range (minimum, maximum + 1);
		for(int i=0; i<objectCount; i++)
			{
				Vector3 randomPosition = RandomPosition ();
				GameObject tileChoice = outerTileArray [Random.Range (0, outerTileArray.Length)];
				Instantiate(tileChoice, randomPosition, Quaternion.identity);
			}
	}


	public void SetupScene (int level)
	{
		BoardSetup ();
		//InitialiseList ();
		//Instantiate (path, new Vector3 (columns -1, rows -1. 0f), Quaternion.identity);
	}
}

