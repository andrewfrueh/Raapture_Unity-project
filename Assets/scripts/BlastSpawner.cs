using UnityEngine;
using System.Collections;

public class BlastSpawner : MonoBehaviour {

	public GameObject prefabObj_Lightning;
	public GameObject prefabObj_BlastMiss;
	public GameObject prefabObj_BlastHitSheep;

	public AudioClip sound_blast;

	void Start () {
		//sound_blast.
	}
	
	void Update () {
		// NOTES:
		// Input.GetButton - always while down
		// Input.GetButtonDown - only the first click
		if (Input.GetButtonDown ("Fire1")) {
			Vector2 clickPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			//Debug.Log("click: " + clickPoint);
			SpawnBlast(clickPoint);
			//GameGlobals.energyLevel -= GameGlobals.energyDownFromBlast;
			GameGlobals.EnergyLevel_Blast();
		}
	}

	void SpawnBlast(Vector2 clickPoint){
		//Debug.Log ("SpawnBlast @ " + clickPoint);
		GetComponent<AudioSource>().PlayOneShot (sound_blast);

		//
		Vector3 lightningPos = 
			new Vector3( clickPoint.x, //cameraPos.x + Random.Range(xMax - xRange, xMax),
			            clickPoint.y,
			            -1);
		Vector3 blastPos = 
			new Vector3( clickPoint.x, //cameraPos.x + Random.Range(xMax - xRange, xMax),
			            clickPoint.y,
			            -5);
		// make the lightning
		GameObject newLightning = Instantiate(prefabObj_Lightning, lightningPos, Quaternion.identity) as GameObject;
		// make the blast
		GameObject newBlast = Instantiate(prefabObj_BlastMiss, blastPos, Quaternion.identity) as GameObject;
	}

}
