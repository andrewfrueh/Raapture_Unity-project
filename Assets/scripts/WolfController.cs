using UnityEngine;
using System.Collections;

public class WolfController : MonoBehaviour {
	
	public float moveSpeed;
	public bool xInverted = false;
	public float ascendSpeed = 2f; 
	public int wolfMaxHealth = 3;
	public int blastDamage = 1;

	private bool wolfIsOnFire;
	private bool wolfIsDead;
	private int myHealth;

	public AudioClip sound_damage;
	public AudioClip sound_death;
	public AudioClip sound_bite;

	private float yPosOffset = 0.3F;

	
	// Use this for initialization
	void Start () {
		moveSpeed = GameGlobals.wolfMoveSpeed;
		// set velocity
		GetComponent<Rigidbody2D>().velocity = new Vector2(xInverted ? -moveSpeed : moveSpeed, 0);
		// flip in x is inverted
		transform.localScale = new Vector3 (xInverted ? -1 : 1, transform.localScale.y, transform.localScale.z);

		// health
		myHealth = wolfMaxHealth;

	}
	
	// Update is called once per frame
	void Update () {
	}


	public void WolfTakeDamage(){
		Debug.Log ("WolfTakeDamage - Why do I yelp on spawn???");
		myHealth -= blastDamage;
		// trigger fire animation
		Transform temp;
		temp = transform.FindChild ("fire "+myHealth);
		//temp.GetComponent<Animator> ().SetBool ("FireIsBurning", true);
		temp.GetComponent<Animator> ().enabled = true;
		temp.GetComponent<SpriteRenderer> ().enabled = true;
		//
		GetComponent<AudioSource>().PlayOneShot (sound_damage);
		// dead?
		if (myHealth == 0) {
			WolfDeath();
		}
	}

	public void WolfDeath(){
		if (!wolfIsDead) {
			//Debug.Log ("wolf death");
			wolfIsDead = true;
			GetComponent<Collider2D>().enabled = false;

			//
			GetComponent<AudioSource>().PlayOneShot (sound_death);
			// trigger death animation
			Transform temp;
			temp = transform.FindChild ("wolf");

			temp.GetComponent<Animator> ().SetBool ("WolfBlasted", true);
			// change velocity 
			GetComponent<Rigidbody2D>().velocity = new Vector2 (0, ascendSpeed);
			//
			GameGlobals.wolfKilledCount++;
			GameGlobals.currentNumberOfWolves--;
		}
	}



	// when the game obj leaves the screen...
	public void OnBecameInvisible()
	{
		//Debug.Log ("OnBecameInvisible:" + this);
		//Destroy( gameObject ); 
		Invoke ("RespawnMe", .5f);
	}

	void RespawnMe(){
		//Debug.Log ("RespawnMe:");
		GameObject[] allCurrentSheep = GameObject.FindGameObjectsWithTag("sheep");

		if (allCurrentSheep.Length > 0) {
			// use last sheep
			Vector3 selectedSpawnPosition = new Vector3 ();

			foreach (GameObject sheep in allCurrentSheep) {
				selectedSpawnPosition = sheep.GetComponent<SheepController>().mySpawnPosition;
				if (Random.Range (0, 6) == 0)
					break;
				
			}
			
			// flip?
			int sideFlip = Random.Range (0, 2);
			
			// spawn position
			Vector3 newPos = 
				new Vector3 (sideFlip == 1 ? -(GameGlobals.screenSizeX / 2)-2 : (GameGlobals.screenSizeX / 2)+2, //cameraPos.x + Random.Range(xMax - xRange, xMax),
				             selectedSpawnPosition.y + yPosOffset,
				             selectedSpawnPosition.z + 0F);
			
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
		} else {
			// redo spawn, hopefully sheep next time
			Invoke ("RespawnMe", .5f);

		}
	}

	// this method handles collisions
	void OnTriggerEnter2D (Collider2D other)
	{
		Debug.Log ("other:" + other.tag);
		//
		if (other.CompareTag ("blast")) {
			WolfTakeDamage();
		} else 	if (other.CompareTag ("sheep") &&
		            other.transform.position.z == transform.position.z) {

			// trigger attack animation
			Transform temp;
			temp = transform.FindChild ("wolf");
			temp.GetComponent<Animator> ().SetBool ("WolfAttack", true);

			// kill the sheep
			other.GetComponentInParent<SheepController>().IWasEaten();

			// play bite sound
			GetComponent<AudioSource>().PlayOneShot(sound_bite);


		}

	}


	public void KillMe(){
		//Debug.Log ("KillMe");
		//
		Destroy( gameObject ); 
	}


	
	
}
