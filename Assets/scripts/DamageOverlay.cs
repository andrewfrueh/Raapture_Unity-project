using UnityEngine;
using System.Collections;

public class DamageOverlay : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setDamageFalse(){
		GetComponent<Animator> ().SetBool ("damage", false);
	}
	public void setBlastFalse(){
		GetComponent<Animator> ().SetBool ("blast", false);
	}
}
