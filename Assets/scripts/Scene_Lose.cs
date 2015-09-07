using UnityEngine;
using System.Collections;

public class Scene_Lose : MonoBehaviour {

	public float startupDelayTime = 2f;
	private bool startupDelayComplete;

	public AudioClip sound_music;
	
	// Use this for initialization
	void Start () {
		GetComponent<AudioSource>().PlayOneShot (sound_music);
		Invoke ("StartupDelay", startupDelayTime);
	}

	void StartupDelay(){
		startupDelayComplete = true;
	}

	// Update is called once per frame
	void Update () {
		// check for click
		if (Input.GetButton ("Fire1") && startupDelayComplete) {
			//LoadLevel();
			//Vector2 clickPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			Application.LoadLevel("SplashScreen");
		}

	}
}
