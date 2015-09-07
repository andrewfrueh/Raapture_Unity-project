using UnityEngine;
using System.Collections;

public class BloodSplatController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Vector3 newPos = new Vector3 (transform.position.x, transform.position.y, transform.position.z - 1);
		transform.position = newPos;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void KillMe(){
		Destroy (gameObject);
	}

}
