using UnityEngine;
using System.Collections;

public class SheepCounterGUI : MonoBehaviour
{
	//
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
	
	// got this from: http://answers.unity3d.com/questions/384623/setting-font-size-according-to-screen-dpi.html
	//labelStyle.fontSize = (int) (Screen.width * 0.04f);
	void OnGUI () {
		// this resizes the font based on the resolution so it's the same relative shape
		myStyle.fontSize = (int) (Screen.width * 0.12f);
		GUI.Label (new Rect ( myScreenPosition.x, myScreenPosition.y, 50, 50 ), 
		           "" + GameGlobals.sheepRapturedCount, 
		           myStyle);

	}
}

