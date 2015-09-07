using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnMouseDown(){
		Debug.Log ("onMouseDown: "+this.name);
		StartGame(this.name);
	}


	void StartGame(string buttonName){

		// first set up the difficulty level 
		if (this.name == "button_easy") {
			GameGlobals.SetGameDifficulty("easy");
		}else if(this.name == "button_medium"){
			GameGlobals.SetGameDifficulty("medium");
		}else if(this.name == "button_hard"){
			GameGlobals.SetGameDifficulty("hard");
		}

		// start the game
		Application.LoadLevel ("GamePlay");
	}

}
