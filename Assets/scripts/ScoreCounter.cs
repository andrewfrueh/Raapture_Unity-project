using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreCounter : MonoBehaviour {

	//
	private Text myText;

	// Use this for initialization
	void Start () {
		myText = gameObject.GetComponent<Text>();

	}
	
	// Update is called once per frame
	void Update () {
		myText.text = GameGlobals.sheepRapturedCount.ToString();
	}
}
