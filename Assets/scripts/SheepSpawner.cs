using UnityEngine;
using System.Collections;

public class SheepSpawner : MonoBehaviour
{
	
	// min and max spawn time
	public float minSpawnTime = 1f; 
	public float maxSpawnTime = 1f; 
	// min max speed
	public int minMoveSpeed = 3;
	public int maxMoveSpeed = 15;
	
	// the prefab to use
	public GameObject prefabObj;
	
	// the spawn points to use
	public GameObject[] spawnPoints;
	
	//

	// Use this for initialization
	void Start ()
	{
		// transfer the values set in the editor to the gameglobals
		GameGlobals.sheepSpawnSpeedRange [0] = minSpawnTime;
		GameGlobals.sheepSpawnSpeedRange [1] = maxSpawnTime;
		GameGlobals.sheepMoveSpeedRange [0] = minMoveSpeed;
		GameGlobals.sheepMoveSpeedRange [1] = maxMoveSpeed;

		GameGlobals.UpdateGameDifficulty ();
		Invoke("SpawnNew",0.5f);
	}

	//
	void SpawnNew(){
		//
		float xMax = (Camera.main.aspect * Camera.main.orthographicSize);
		//
		Vector3 newPos = new Vector3 (xMax*2, 0, 0);
		//
		GameObject newObj = Instantiate (prefabObj, newPos, Quaternion.identity) as GameObject;
		newObj.GetComponent<SheepController> ().RespawnMe ();
		//
		Invoke ("SpawnNew", GameGlobals.sheepSpawnSpeed );

	}


	void AddNewSpawnPoint(GameObject newSpawnObj){
		if (GameGlobals.sheepMaxSpawnPoints > 0) {
			for (int i=0; i<GameGlobals.sheepMaxSpawnPoints-1; i++) {
				GameGlobals.sheepLastSpawnPoints [i] = GameGlobals.sheepLastSpawnPoints [i + 1];
			}
			GameGlobals.sheepLastSpawnPoints [GameGlobals.sheepMaxSpawnPoints - 1] = newSpawnObj;
		}
	}

}

