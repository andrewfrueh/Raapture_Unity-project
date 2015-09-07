using UnityEngine;
using System.Collections;

public class WolfSpawner : MonoBehaviour
{
	
	// min and max spawn time
	public float minSpawnTime = 10f; 
	public float maxSpawnTime = 10f; 
	// min max speed
	public int minMoveSpeed = 6;
	public int maxMoveSpeed = 20;

	// the prefab to use
	public GameObject prefabObj;
	
	// the spawn points to use
	public GameObject[] spawnPoints;
	
	public float wolfResurrectionTime = 10;
	private bool wolfIsBeingResurrected;

	public int maxNumberOfWolves = 3;

	public int sheepMaxSpawnPoints = 3;


	// Use this for initialization
	void Start ()
	{
		// transfer the values set in the editor to the gameglobals
		GameGlobals.wolfSpawnRateRange [0] = minSpawnTime;
		GameGlobals.wolfSpawnRateRange [1] = maxSpawnTime;
		GameGlobals.wolfMoveSpeedRange [0] = minMoveSpeed;
		GameGlobals.wolfMoveSpeedRange [1] = maxMoveSpeed;

		Invoke("SpawnNew",minSpawnTime);
		GameGlobals.sheepMaxSpawnPoints = sheepMaxSpawnPoints;
		
	}

	/*
	void Update(){
		if (GameGlobals.wolfIsDead && !wolfIsBeingResurrected) {
			wolfIsBeingResurrected = true;
			Invoke ("ResurrectWolf", wolfResurrectionTime);
		}
	}
	
	void ResurrectWolf(){
		wolfIsBeingResurrected = false;
		GameGlobals.wolfIsDead = false;
		SpawnNew ();
	}
	*/
	void SpawnNew(){

		//Debug.Log ("Spawn:" + GameGlobals.gameDifficulty);

		GameObject[] allCurrentSheep = GameObject.FindGameObjectsWithTag("sheep");

		if (allCurrentSheep.Length > 0 && GameGlobals.currentNumberOfWolves < maxNumberOfWolves) {
			
			//
			GameGlobals.currentNumberOfWolves ++;
			
			// establish the frame boundries
			Camera camera = Camera.main;
			float xMax = (camera.aspect * camera.orthographicSize) + 1;
			float yMax = camera.orthographicSize;
			
			/*
		// pick a random spawn point
		int selectedSpawnIndex = Random.Range (0, spawnPoints.Length);
		GameObject selectedSpawnObj = spawnPoints [selectedSpawnIndex];
		Vector3 selectedSpawnPosition = selectedSpawnObj.transform.position;
*/
			
			// use last sheep
			Vector3 selectedSpawnPosition = new Vector3 ();
			//Debug.Log ("=====================================");
			foreach (GameObject sheep in allCurrentSheep) {
				//Debug.Log (sheep.transform.position);
				//selectedSpawnPosition = sheep.transform.position;
				selectedSpawnPosition = sheep.GetComponent<SheepController> ().mySpawnPosition;
				
				if (Random.Range (0, allCurrentSheep.Length) == 0)
					break;
			}
			
			//Vector3 selectedSpawnPosition = chosenSheep.GetComponent<SheepController>().mySpawnPosition;
			//Debug.Log("sheepMaxSpawnPoints:"+GameGlobals.sheepMaxSpawnPoints);
			//GameObject selectedSpawnObj = GameGlobals.sheepLastSpawnPoints [0];
			
			//Debug.Log ("selectedSpawnObj:"+selectedSpawnObj);
			
			// flip?
			int sideFlip = Random.Range (0, 2);
			
			// spawn position
			Vector3 newPos = 
				new Vector3 (sideFlip == 1 ? -xMax : xMax, //cameraPos.x + Random.Range(xMax - xRange, xMax),
				             selectedSpawnPosition.y + 0F,
				             selectedSpawnPosition.z + 0F);
			
			
			// make the new object (spawn)
			GameObject newObj = Instantiate (prefabObj, newPos, Quaternion.identity) as GameObject;
			
			//Debug.Log ("newObj: " + newObj.tag);
			//Debug.Log ("sideFlip: " + sideFlip);
			
			// fix for flip?
			if (sideFlip == 0) {
				newObj.GetComponent<WolfController> ().xInverted = true;
			} else {
				newObj.GetComponent<WolfController> ().xInverted = false;
			}
			/*
			if (!GameGlobals.wolfIsDead) {
				// set up next spawn
				Invoke ("SpawnNew", Random.Range (minSpawnTime, maxSpawnTime));
			} */
			Invoke ("SpawnNew", GameGlobals.wolfSpawnRate );
		} else {// end if()	
			// there were no sheep, or too many wolves, so try to spawn again
			Invoke ("SpawnNew", 0.5F );
		}
		//Invoke ("SpawnNew", Random.Range (minSpawnTime, maxSpawnTime));

	}
	
}

