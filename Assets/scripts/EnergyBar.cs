using UnityEngine;
using System.Collections;

public class EnergyBar : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 scaleTemp = new Vector3( 1, GameGlobals.energyLevel/100F, 1 );
		//Debug.Log("scale:" + scaleTemp );
		transform.localScale = scaleTemp;
	}
}
