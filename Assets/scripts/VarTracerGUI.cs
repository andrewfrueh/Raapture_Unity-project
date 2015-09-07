using UnityEngine;
using System.Collections;

public class VarTracerGUI : MonoBehaviour
{

	public GUIStyle myStyle;
	//private Transform myPosition;
	private Vector3 myPosition;
	private Vector3 myScreenPosition;
	private Vector2 myGUIPosition;
	
	//private Vector2 screenSize = {};
	
	// Use this for initialization
	void Start () {
		GetGUIPosition ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void GetGUIPosition(){
		// this code finds the alignment object in the UI and gets the position for placement of the label.
		myPosition = this.transform.position;
		myScreenPosition = Camera.main.WorldToScreenPoint (new Vector3(myPosition.x, -myPosition.y, myPosition.z));
		Vector2 gPos = new Vector2(myPosition.x, myPosition.y);
		myGUIPosition = GUIUtility.ScreenToGUIPoint(gPos);
	}
	
	void OnGUI () {
		//myStyle = GUI.skin.label;
		GUI.Label (new Rect (myScreenPosition.x,myScreenPosition.y,90,50), 
		           "energy level: " + GameGlobals.energyLevel +  
		           "\ngame difficulty: " + GameGlobals.gameDifficulty +  
		           "\nsheep raptured: " + GameGlobals.sheepRapturedCount +
		           "\nsheep eaten: " + GameGlobals.sheepEatenCount +
		           //"\nwolf escaped: " + GameGlobals.wolfEscapedCount +  
		           "\nwolf killed: " + GameGlobals.wolfKilledCount
		           , myStyle);
	}
}

