using UnityEngine;
using System.Collections;

public class SheepInner : MonoBehaviour {

	// a reference to the parent carrier obj
	private SheepController myController;

	// Use this for initialization
	void Start () {
		myController = transform.parent.GetComponent<SheepController>();  
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// when the game obj leaves the screen...
	void OnBecameInvisible()
	{
		//Debug.Log ("OnBecameInvisible *inner*:" + this);
		//Destroy( gameObject ); 
		myController.OnBecameInvisible ();
	}

	public void KillMe(){
		myController.KillMe ();
	}

}
