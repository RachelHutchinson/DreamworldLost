using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class WinBoardManager : MonoBehaviour {

	public int innerColumns = 8;
	public int innerRows =  8;
	public GameObject player;
	public GameObject owl;
	public GameObject nurse;
	public GameObject music;
	public GameObject librarian;
	public GameObject girlTwin;
	public GameObject boyTwin;
	public GameObject bed;
	public GameObject chest;
	public GameObject rug;
	public GameObject [] innerTiles;
	public GameObject [] innerWalls;
	public AudioClip innerRoom;

	private Transform boardHolder2;
	private List <Vector3> gridPositions = new List <Vector3> ();

	void BoardSetup()
	{
		boardHolder2 = new GameObject ("Board").transform;
		//Room 1
		for (int x = -1; x < innerColumns + 1; x++) {
			for (int y = -1; y < innerRows + 1; y++) {
				GameObject toInstantiate = innerTiles[Random.Range (0, innerTiles.Length)];
				if (x == -1 || x == innerColumns || y == -1 || y == innerRows)
					toInstantiate = innerWalls[Random.Range (0, innerTiles.Length)];
				GameObject instance =
					Instantiate (toInstantiate, new Vector3 (x, y, 0f), Quaternion.identity) as GameObject;
				instance.transform.SetParent (boardHolder2);
			}
		}
		Instantiate (owl, new Vector3 (3, 7, 0f), Quaternion.identity);
		Instantiate (player, new Vector3 (3, 3, 0f), Quaternion.identity);
		Instantiate (nurse, new Vector3 (1, 2, 0f), Quaternion.identity);
		Instantiate (boyTwin, new Vector3 (3, 0, 0f), Quaternion.identity);
		Instantiate (girlTwin, new Vector3 (4, 0, 0f), Quaternion.identity);
		Instantiate (music, new Vector3 (5, 7, 0f), Quaternion.identity);
		Instantiate (librarian, new Vector3 (0, 5, 0f), Quaternion.identity);
		Instantiate (bed, new Vector3 (7, 7, 0f), Quaternion.identity);
		Instantiate (chest, new Vector3 (5, 7, 0f), Quaternion.identity);
		Instantiate (rug, new Vector3 (4, 3, 0f), Quaternion.identity);

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

	void InitialiseList ()
	{
		gridPositions.Clear();
		}


	public void SetupScene (int level)
	{
		//SoundManager.instance.MainMusic (innerRoom);
		BoardSetup ();
		InitialiseList ();
	}


}
