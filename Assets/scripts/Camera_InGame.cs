using UnityEngine;
using System.Collections;

public class Camera_InGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameGlobals.mainCamera = Camera.main;
		GameGlobals.screenSizeX = ((GetComponent<Camera>().aspect * GetComponent<Camera>().orthographicSize) + 1) * 2;
		GameGlobals.screenSizeY = (GetComponent<Camera>().orthographicSize) * 2;

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.Escape)) {
			// escape
			Application.Quit ();
		}

	}
}
