using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
	
	// min and max spawn time
	public float minSpawnTime = 0.75f; 
	public float maxSpawnTime = 4f; 
	
	// the prefab to use
	public GameObject prefabObj;
	
	// the spawn points to use
	public GameObject[] spawnPoints;

	//
	public GameObject lastSpawnedObject;
	public GameObject lastSpawnPoint;
	
	// Use this for initialization
	void Start ()
	{
		Invoke("SpawnNew",minSpawnTime);
	}
	
	void SpawnNew(){
		
		// establish the frame boundries
		Camera camera = Camera.main;
		float xMax = (camera.aspect * camera.orthographicSize) + 1;
		float yMax = camera.orthographicSize;
		
		// pick a random spawn point
		int selectedSpawnIndex = Random.Range (0, spawnPoints.Length);
		GameObject selectedSpawnObj = spawnPoints [selectedSpawnIndex];
		lastSpawnPoint = selectedSpawnObj;
		// flip?
		int sideFlip = Random.Range (0, 2);
		
		// spawn position
		Vector3 newPos = 
			new Vector3 (sideFlip == 1 ? -xMax : xMax, //cameraPos.x + Random.Range(xMax - xRange, xMax),
			             selectedSpawnObj.transform.position.y + .5F,
			             selectedSpawnObj.transform.position.z + .5F);


		// make the new object (spawn)
		GameObject newObj = Instantiate (prefabObj, newPos, Quaternion.identity) as GameObject;
		lastSpawnedObject = newObj;
		//Debug.Log ("newObj: " + newObj.tag);
		//Debug.Log ("sideFlip: " + sideFlip);

		if (newObj.tag == "sheep") {
			// fix for flip?
			if (sideFlip == 0) {
				newObj.GetComponent<SheepController> ().xInverted = true;
			} else {
				newObj.GetComponent<SheepController> ().xInverted = false;
			}
		} else if (newObj.tag == "wolf") {
			// fix for flip?
			if (sideFlip == 0) {
				newObj.GetComponent<WolfController> ().xInverted = true;
			} else {
				newObj.GetComponent<WolfController> ().xInverted = false;
			}
		}

		// set up next spawn
		Invoke ("SpawnNew", Random.Range (minSpawnTime, maxSpawnTime));
		
	}
	
}

