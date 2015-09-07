using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighScoreDisplay : MonoBehaviour {

	private Text myText;

	// Use this for initialization
	void Start () {

		GameGlobals.ResetForNewGame ();

		myText = gameObject.GetComponent<Text>();
		myText.text = GameGlobals.sheepRapturedHighScore.ToString();
		//Debug.Log ("HS:" + GameGlobals.sheepRapturedHighScore);
	}
	
	// Update is called once per frame
	void Update () {

	}
}
