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
	public GameObject floorB;
	public GameObject floorG;
	public GameObject floorM;
	public GameObject floorL;
	public GameObject darkI;
	public GameObject darkO;
	public GameObject darkB;
	public GameObject flower;
	public GameObject coverWallO;
	public GameObject coverWallT;
	public GameObject boyP;
	public GameObject [] treeTiles;
	public GameObject [] innerTiles;
	public GameObject [] outerTiles;
	public GameObject [] innerWalls;
	public GameObject [] outerWalls;
	public GameObject [] bossTiles;
	public GameObject [] bossWalls;
	public AudioClip innerRoom;

	private Transform boardHolder;
	private List <Vector3> gridPositions = new List <Vector3> ();


	void BoardSetup()
	{
		boardHolder = new GameObject ("Board").transform;
		//Room 1
		for (int x = -1; x < innerColumns + 1; x++) {
			for (int y = -1; y < innerRows + 1; y++) {
				if (x == 8 && y == 3) { continue; }
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
				if (x == 9 && y == 3) { continue; }
				if (x == 9 && y == 23) { continue; }
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
				if (x == 15 && y == 1) { continue; }
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
		Instantiate (nurse, new Vector3 (18, 14, 0f), Quaternion.identity);
		//Flower
		Instantiate (flower, new Vector3 (18, -13, 0f), Quaternion.identity);
		//Owl
		Instantiate (owl, new Vector3 (3, 7, 0f), Quaternion.identity);
		//BoyTwin
		Instantiate (boyTwin, new Vector3 (16, -15, 0f), Quaternion.identity);
		//GirlTwin
		Instantiate (girlTwin, new Vector3 (17, -15, 0f), Quaternion.identity);
		//Librarian
		Instantiate (librarian, new Vector3 (11, -3, 0f), Quaternion.identity);
		//Boss
		Instantiate (boss, new Vector3 (-5, 28, 0f), Quaternion.identity);
		//Music
		Instantiate (music, new Vector3 (22, -4, 0f), Quaternion.identity);
		// Darkness
		GameObject dark =
			Instantiate (darkI, new Vector3 (3, 3, 0f), Quaternion.identity) as GameObject;
		GameObject dark1 =
			Instantiate (darkO, new Vector3 (18, 2, 0f), Quaternion.identity) as GameObject;
		GameObject dark2 =
			Instantiate (darkB, new Vector3 (-5, 22, 0f), Quaternion.identity) as GameObject;
		//Add darkness to countdown for reset
		GameObject timer = GameObject.Find ("Timer");
		CountDown countDown = timer.GetComponent<CountDown> ();
		countDown.darkI = dark;
		countDown.darkO = dark1;
		countDown.darkB = dark2;
		//CoverWalls
		GameObject coverWall1 =
			Instantiate (coverWallO, new Vector3 (8, 3, 0f), Quaternion.identity) as GameObject;
		GameObject coverWall2 =
			Instantiate (coverWallT, new Vector3 (9, 23, 0f), Quaternion.identity) as GameObject;
		//Path
		Instantiate (path, new Vector3 (7, 3, 0f), Quaternion.identity);
		Instantiate (path, new Vector3 (8, 3, 0f), Quaternion.identity);
		GameObject gPath =
			Instantiate (pathT, new Vector3 (9, 3, 0f), Quaternion.identity) as GameObject;

		Pathways pathScript = gPath.GetComponent<Pathways> ();
		pathScript.player = playerI;
		pathScript.darkI = dark;
		pathScript.darkO = dark1;
		pathScript.coverWall = coverWall1;

		Instantiate (path, new Vector3 (10, 3, 0f), Quaternion.identity);
		Instantiate (path, new Vector3 (6, 3, 0f), Quaternion.identity);

		dark.SetActive (false);
		//Special Tiles
		Instantiate (floorT, new Vector3 (2, 7, 0f), Quaternion.identity);
		Instantiate (floorH, new Vector3 (0, 3, 0f), Quaternion.identity);
		Instantiate (floorB, new Vector3 (3, 0, 0f), Quaternion.identity);
		Instantiate (boyP, new Vector3 (3, 0, 0f), Quaternion.identity);
		Instantiate (floorG, new Vector3 (4, 0, 0f), Quaternion.identity);
		Instantiate (floorM, new Vector3 (7, 2, 0f), Quaternion.identity);
		Instantiate (floorL, new Vector3 (0, 5, 0f), Quaternion.identity);
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
		PathToBoss pathScript2 = qPath.GetComponent<PathToBoss> ();
		pathScript2.player = playerI;
		pathScript2.dark = dark1;
		pathScript2.darkB = dark2;
		pathScript2.coverWall = coverWall2;

		Instantiate (path, new Vector3 (9, 23, 0f), Quaternion.identity);
		//Bush
		Instantiate (plantA, new Vector3 (10, 20, 0f), Quaternion.identity);
		Instantiate (plantB, new Vector3 (22, -15, 0f), Quaternion.identity);
		Instantiate (plantA, new Vector3 (14, -3, 0f), Quaternion.identity);
		Instantiate (plantB, new Vector3 (20, 3, 0f), Quaternion.identity);

		// Tree Set Up
		Instantiate (treeTiles[0], new Vector3 (15, -14, 0f), Quaternion.identity);
		Instantiate (treeTiles[1], new Vector3 (16, -14, 0f), Quaternion.identity);
		Instantiate (treeTiles[2], new Vector3 (17, -14, 0f), Quaternion.identity);
		Instantiate (treeTiles[3], new Vector3 (15, -13, 0f), Quaternion.identity);
		Instantiate (treeTiles[4], new Vector3 (16, -13, 0f), Quaternion.identity);
		Instantiate (treeTiles[5], new Vector3 (17, -13, 0f), Quaternion.identity);
		Instantiate (treeTiles[6], new Vector3 (15, -12, 0f), Quaternion.identity);
		Instantiate (treeTiles[7], new Vector3 (16, -12, 0f), Quaternion.identity);
		Instantiate (treeTiles [8], new Vector3 (17, -12, 0f), Quaternion.identity);
		Instantiate (treeTiles[9], new Vector3 (15, -11, 0f), Quaternion.identity);
		Instantiate (treeTiles[10], new Vector3 (16, -11, 0f), Quaternion.identity);
		Instantiate (treeTiles[11], new Vector3 (17, -11, 0f), Quaternion.identity);
		Instantiate (treeTiles[12], new Vector3 (15, -10, 0f), Quaternion.identity);
		Instantiate (treeTiles[13], new Vector3 (16, -10, 0f), Quaternion.identity);
		Instantiate (treeTiles[14], new Vector3 (17, -10, 0f), Quaternion.identity);
		Instantiate (treeTiles[15], new Vector3 (16, -9, 0f), Quaternion.identity);

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
		SoundManager.instance.MainMusic (innerRoom);
		BoardSetup ();
		InitialiseList ();
	}


}

