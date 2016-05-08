using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour {

	public int innerColumns = 10;
	public int innerRows = 10;
	public int outerColumns = 60;
	public int outerRows = 50;
	public int bossColumns = 15;
	public int bossRows = 6;
	public GameObject player;
	public GameObject owl;
	public GameObject nurse;
	public GameObject music;
	public GameObject boss;
	public GameObject path;
	public GameObject plantA;
	public GameObject plantB;
	public GameObject pathT;
	public GameObject pathE;
	public GameObject librarian;
	public GameObject girlTwin;
	public GameObject boyTwin;
	public GameObject floorT;
	public GameObject floorH;
	public GameObject healthPick;
	public GameObject [] innerTiles;
	public GameObject [] outerTiles;
	public GameObject [] innerWalls;
	public GameObject [] outerWalls;
	public GameObject [] bossTiles;
	public GameObject [] bossWalls;

	private Transform boardHolder;
	private List <Vector3> gridPositions = new List <Vector3> ();


	void BoardSetup()
	{
		boardHolder = new GameObject ("Board").transform;
		//Room 1
		for (int x = -1; x < innerColumns + 1; x++) {
			for (int y = -1; y < innerRows + 1; y++) {
				GameObject toInstantiate = innerTiles [Random.Range (0, innerTiles.Length)];
				if (x == -1 || x == innerColumns || y == -1 || y == innerRows)
					toInstantiate = innerWalls [Random.Range (0, innerWalls.Length)];
				GameObject instance =
					Instantiate (toInstantiate, new Vector3 (x, y, 0f), Quaternion.identity) as GameObject;
			}
		}
		//Room 2
		for (int x = 9; x < outerColumns + 1; x++) {
			for (int y = -20; y < outerRows + 1; y++) {
				GameObject toInstantiate = outerTiles [Random.Range (0, outerTiles.Length)];
				if (x == 9 || x == outerColumns || y == -20 || y == outerRows)
					toInstantiate = outerWalls [Random.Range (0, outerWalls.Length)];
				GameObject instance =
					Instantiate (toInstantiate, new Vector3 (x, y, 0f), Quaternion.identity) as GameObject;
			}
		}
		//boss 1
		for (int x = -10; x < bossColumns + 1; x++) {
			for (int y = 0; y < bossRows + 1; y++) {
				GameObject toInstantiate = bossTiles [Random.Range (0, bossTiles.Length)];
				if (x == -10 || x == bossColumns || y == 0 || y == bossRows)
					toInstantiate = bossWalls [Random.Range (0, bossWalls.Length)];
				GameObject instance =
					Instantiate (toInstantiate, new Vector3 (x - 7, y + 22, 0f), Quaternion.identity) as GameObject;
				instance.transform.SetParent (boardHolder);
			}
		}
		//Player
		GameObject playerI =
			Instantiate (player, new Vector3 (3, 3, 0f), Quaternion.identity) as GameObject;
		//Nurse
		GameObject nurseI =
			Instantiate (nurse, new Vector3 (18, 14, 0f), Quaternion.identity) as GameObject;
		//Owl
		GameObject owlI =
			Instantiate (owl, new Vector3 (3, 7, 0f), Quaternion.identity) as GameObject;
		//BoyTwin
		GameObject boyI =
			Instantiate (boyTwin, new Vector3 (10, -3, 0f), Quaternion.identity) as GameObject;
		//GirlTwin
		GameObject girlI =
			Instantiate (girlTwin, new Vector3 (11, -3, 0f), Quaternion.identity) as GameObject;
		//Librarian
		GameObject lib =
			Instantiate (librarian, new Vector3 (20, -7, 0f), Quaternion.identity) as GameObject;
		//Boss
		GameObject bos =
			Instantiate (boss, new Vector3 (-5, 28, 0f), Quaternion.identity) as GameObject;
		//Music
		GameObject musicI =
			Instantiate (music, new Vector3 (22, -4, 0f), Quaternion.identity) as GameObject;
		//Health Pickup
		GameObject healthP =
			Instantiate (healthPick, new Vector3 (0, 3, 0f), Quaternion.identity) as GameObject;
		//Path
		GameObject cPath =
			Instantiate (path, new Vector3 (8, 3, 0f), Quaternion.identity) as GameObject;
		GameObject dPath =
			Instantiate (path, new Vector3 (9, 3, 0f), Quaternion.identity) as GameObject;
		GameObject gPath =
			Instantiate (pathT, new Vector3 (7, 3, 0f), Quaternion.identity) as GameObject;
		GameObject hPath =
			Instantiate (path, new Vector3 (10, 3, 0f), Quaternion.identity) as GameObject;
		GameObject iPath =
			Instantiate (pathT, new Vector3 (6, 3, 0f), Quaternion.identity) as GameObject;
		//Special Tiles
		GameObject fT =
			Instantiate (floorT, new Vector3 (2, 7, 0f), Quaternion.identity) as GameObject;
		GameObject hT =
			Instantiate (floorH, new Vector3 (0, 3, 0f), Quaternion.identity) as GameObject;
		//Path to Boss
		for (int x = 3; x < 3 + 1; x++) {
			for (int y = 3; y < 23 + 1; y++) 
			{
			GameObject toInstantiate = path;
			GameObject instance =
					Instantiate (toInstantiate, new Vector3 (x + 8, y, 0f), Quaternion.identity) as GameObject;
			}
		}
		GameObject qPath =
			Instantiate (pathE, new Vector3 (10, 23, 0f), Quaternion.identity) as GameObject;
		GameObject rPath =
			Instantiate (path, new Vector3 (9, 23, 0f), Quaternion.identity) as GameObject;
		GameObject sPath =
			Instantiate (path, new Vector3 (8, 23, 0f), Quaternion.identity) as GameObject;
		//Bush
		GameObject aPlant =
			Instantiate (plantA, new Vector3 (10, 20, 0f), Quaternion.identity) as GameObject;
		GameObject bPlant = 
			Instantiate (plantB, new Vector3 (22, -15, 0f), Quaternion.identity) as GameObject;
		GameObject cPlant =
			Instantiate (plantA, new Vector3 (14, -3, 0f), Quaternion.identity) as GameObject;
		GameObject dPlant =
			Instantiate (plantB, new Vector3 (20, 3, 0f), Quaternion.identity) as GameObject;
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
		for(int x = 1; x<outerColumns-1; x++)
		{for (int y = 1; y < outerRows - 1; y++)
				gridPositions.Add (new Vector3 (x, y, 0f));
		}
	}
			

	public void SetupScene (int level)
	{
		BoardSetup ();
		InitialiseList ();
	}
}

