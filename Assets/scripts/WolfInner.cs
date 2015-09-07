using UnityEngine;
using System.Collections;

public class WolfInner : MonoBehaviour {
	
	// a reference to the parent carrier obj
	private WolfController myController;
	
	// Use this for initialization
	void Start () {
		myController = transform.parent.GetComponent<WolfController>();  
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

	void WolfBlasted(){
		//Debug.Log ("WolfBlasted");
		myController.KillMe();
	}


}
