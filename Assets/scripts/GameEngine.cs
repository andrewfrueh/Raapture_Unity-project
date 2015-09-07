using UnityEngine;
using System.Collections;

public class GameEngine : MonoBehaviour {

	private int gameDifficultyIncrease = 1;
	private float gameDifficultyIncreaseRate = 3;

	public AudioClip sound_music;
	public GameObject scoreObject;

	// Use this for initialization
	void Start () {
		//
		GameGlobals.ResetForNewGame ();
		//
		GameGlobals.energyLevel = GameGlobals.energyLevelStart;
		//
		//IncreaseGameDifficulty ();
		GetComponent<AudioSource>().loop = true;
		GetComponent<AudioSource>().clip = sound_music;
		GetComponent<AudioSource>().Play ();
		//audio.Play (sound_music);
	}
	
	// Update is called once per frame
	void Update () {
		//GameGlobals.UpdateGameDifficulty ();
		if (GameGlobals.energyLevel <= 0) {
			// 
			YouLose();
		}

	}

	void LateUpdate(){
		if (Input.GetKeyDown ("z")) {
			
			Debug.Log("screenshot");
			Application.CaptureScreenshot("screenshot_"+System.DateTime.Now.ToString("yyyy_mm_dd_hh_mm")+"_"+Time.timeSinceLevelLoad.ToString()+".png"); // System.DateTime.Now.ToString("yyyy_mm_dd_mm_ss")
		}

	}
	
	void IncreaseGameDifficulty(){
		//Debug.Log("IncreaseGameDifficulty");
		GameGlobals.gameDifficulty += gameDifficultyIncrease;
		GameGlobals.UpdateGameDifficulty ();
		Invoke ("IncreaseGameDifficulty", gameDifficultyIncreaseRate);
	}

	void YouLose(){
		Application.LoadLevel("YouLose");
	}

	//scoreObject

}
