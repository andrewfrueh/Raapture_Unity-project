using UnityEngine;
using System.Collections;

public class BlastController : MonoBehaviour {

	public float blastVisibleTime = .5f;

	// Use this for initialization
	void Start () {
		Invoke ("KillMe", blastVisibleTime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void KillMe(){
		//Debug.Log ("KillMe");
		Destroy( gameObject ); 
	}

	void OnTriggerEnter2D (Collider2D other){
		/*Debug.Log (other.tag);
		if (other.CompareTag ("sheep")) {

		}*/
	}

}
