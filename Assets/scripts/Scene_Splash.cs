using UnityEngine;
using System.Collections;

public class Scene_Splash : MonoBehaviour {
	
	//public float startUpTime = 3f;
	//public GUIStyle myStyle;

	// Use this for initialization
	void Start () {
		//Invoke("LoadLevel", startUpTime);
	}
	
	// Update is called once per frame
	void Update () {
		// check for the back button on Android (same as the escape key)
		if (Input.GetKeyUp (KeyCode.Escape)) {
			// escape
			Application.Quit ();
		}

	}



	void LoadLevel() {
		Application.LoadLevel("GamePlay");
	}

	/*
	void OnGUI () {
		// Make a background box
		GUI.Box(new Rect(10,10,100,90), "");
		
		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(20,20,80,20), "Easy", myStyle)) {
			Application.LoadLevel("GamePlay");
		}
		
		// Make the second button.
		if(GUI.Button(new Rect(20,50,80,20), "Medium", myStyle)) {
			Application.LoadLevel("GamePlay");
		}
		// Make the second button.
		if(GUI.Button(new Rect(20,80,80,20), "Hard", myStyle)) {
			Application.LoadLevel("GamePlay");
		}
	}

*/


}
