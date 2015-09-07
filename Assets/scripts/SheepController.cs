using UnityEngine;
using System.Collections;

public class SheepController : MonoBehaviour {

	public float moveSpeed = 2f;
	public bool xInverted = false;
	public bool iWasBlasted = false;
	public float ascendSpeed = 2f; 
	public GameObject bloodPrefab;
	public float sheepDeathDelay = 0.5f;

	public Vector3 mySpawnPosition;

	public AudioClip choirSound;

	private float yPosOffset = 1.0F;

	
	// Use this for initialization
	void Start () {
		moveSpeed = GameGlobals.sheepMoveSpeed;
		// set velocity
		GetComponent<Rigidbody2D>().velocity = new Vector2(xInverted ? -moveSpeed : moveSpeed, 0);
		// flip in x is inverted
		transform.localScale = new Vector3 (xInverted ? -1 : 1, transform.localScale.y, transform.localScale.z);
		//
		mySpawnPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

	}


	// when the game obj leaves the screen...
	public void OnBecameInvisible()
	{
		//
		Invoke ("RespawnMe", .5f);
	}



	public void RespawnMe(){

		GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("spawnPoint");
		//Debug.Log ("SHEEP:" + allCurrentSheep.Length);
		if (spawnPoints.Length > 0) {

			// pick a random spawn point
			int selectedSpawnIndex = Random.Range (0, spawnPoints.Length);
			GameObject selectedSpawnObj = spawnPoints [selectedSpawnIndex];
			//Debug.Log("Respawn:"+selectedSpawnIndex+":"+selectedSpawnObj);
			//
			//AddNewSpawnPoint (selectedSpawnObj);
			// flip?
			int sideFlip = Random.Range (0, 2);
			
			// spawn position
			Vector3 newPos = 
				new Vector3 (sideFlip == 1 ? -(GameGlobals.screenSizeX / 2)-2 : (GameGlobals.screenSizeX / 2)+2, //cameraPos.x + Random.Range(xMax - xRange, xMax),
				             selectedSpawnObj.transform.position.y + yPosOffset,
				             selectedSpawnObj.transform.position.z + .5F);
			
			transform.position = newPos;

			// fix for flip?
			if (sideFlip == 0) {
				xInverted = true;
			} else {
				xInverted = false;
			}
			
			// set velocity
			GetComponent<Rigidbody2D>().velocity = new Vector2 (xInverted ? -moveSpeed : moveSpeed, 0);
			// flip in x is inverted
			transform.localScale = new Vector3 (xInverted ? -1 : 1, transform.localScale.y, transform.localScale.z);

		}
	}




	// this method handles collisions
	void OnTriggerEnter2D (Collider2D other)
	{

		// if cat, add cat to conga line
		if (other.CompareTag ("blast")) {
			BlastMeToHeaven();
		}

	}

	void BlastMeToHeaven(){
		iWasBlasted = true;

		GameGlobals.SheepRaptured ();

		//GameGlobals.sheepRapturedCount++;
		//GameGlobals.IncreaseGameDifficulty ();
		//GameGlobals.energyLevel += GameGlobals.energyUpFromSheep;
		//GameGlobals.EnergyLevel_SheepAscend ();
		GetComponent<Collider2D>().enabled = false;

		//
		GetComponent<AudioSource>().PlayOneShot(choirSound);
		
		// switch to death animation
		Transform temp = transform.FindChild("sheep");
		//temp.collider2D.enabled = false;
		temp.GetComponent<Animator>().SetBool( "sheepGoToHeaven", true );
		
		// change velocity to up
		GetComponent<Rigidbody2D>().velocity = new Vector2( 0, ascendSpeed );
		//Invoke("KillMe", 
	}

	public void IWasEaten(){
		Invoke ("DeathDelayed", sheepDeathDelay);
	}

	void DeathDelayed(){
		// blood
		GameObject newObj = Instantiate (bloodPrefab, transform.position, Quaternion.identity) as GameObject;
		iWasBlasted = true;
		GameGlobals.sheepEatenCount++;
		GameGlobals.EnergyLevel_WolfAttack ();
		KillMe ();

	}

	public void KillMe(){
		Destroy( gameObject ); 
	}

	

}
