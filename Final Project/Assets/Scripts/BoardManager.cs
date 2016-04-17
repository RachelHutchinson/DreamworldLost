using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour {

	public int innerColumns = 9;
	public int innerRows = 9;
	public int outerColumns = 24;
	public int outerRows = 24;
	public GameObject path;
	public GameObject [] innerTiles;
	public GameObject [] outerTiles;
	public GameObject [] innerWalls;
	public GameObject [] outerWalls;

	private Transform boardHolder;
	private Transform roomHolder;
	private List <Vector3> gridPositions = new List <Vector3> ();


	void BoardSetup()
	{
		boardHolder = new GameObject ("Board").transform;
		for (int x = -1; x < outerColumns + 1; x++) {
			for (int y = -1; y < outerRows + 1; y++) {
				GameObject toInstantiate = outerTiles [Random.Range (0, outerTiles.Length)];
				if (x == -1 || x == outerColumns || y == -1 || y == outerRows)
					toInstantiate = outerWalls [Random.Range (0, outerWalls.Length)];
				GameObject instance =
					Instantiate (toInstantiate, new Vector3 (x, y, 0f), Quaternion.identity) as GameObject;
				instance.transform.SetParent (boardHolder);
			}
	}
	}

	void RoomSetup()
	{
		roomHolder = new GameObject ("Room").transform;
		for (int x = innerColumns; x < innerColumns+ 6; x++) {
			for (int y = innerRows; y < innerRows + 6; y++) {
				GameObject toInstantiate = innerTiles [Random.Range (0, innerTiles.Length)];
				if (x == innerColumns || x == innerColumns + 5 || y == innerRows || y == innerRows + 5)
					toInstantiate = innerWalls [Random.Range (0, innerWalls.Length)];
				GameObject instance =
					Instantiate (toInstantiate, new Vector3 (x, y, 0f), Quaternion.identity) as GameObject;
				instance.transform.SetParent (roomHolder);
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

