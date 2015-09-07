using UnityEngine;
using System.Collections;

public class GameGlobals : MonoBehaviour {
	
	// player energy level
	public static int energyLevel; // 0 - 100
	public static int energyLevelStart = 100;
	public static int[] energyLevelRange = {0,100};
	public static int energyDownFromBlast = 5;
	public static int energyUpFromSheep = 3; // sheep ascended to heaven, so increase your energy
	public static int energyDownFromWolfAttack = 5;

	// 
	public static int gameDifficulty;
	public static int defaultGameDifficulty_easy = 1;
	public static int defaultGameDifficulty_medium = 100;
	public static int defaultGameDifficulty_hard = 200;
	public static int[] gameDifficultyRange = {1,300}; //  --> harder and harder
	public static int gameDifficultyRampSpeed = 3;

	// game object variables
	public static float wolfSpawnRate;
	public static float[] wolfSpawnRateRange = {10F,10F};
	public static int wolfMoveSpeed;
	public static int[] wolfMoveSpeedRange = {6,20};
	//
	public static float sheepSpawnSpeed;
	public static float[] sheepSpawnSpeedRange = {1.0F,0.5F};
	public static int sheepMoveSpeed;
	public static int[] sheepMoveSpeedRange = {3,15};

	// stats
	public static int sheepRapturedCount;
	public static int sheepRapturedHighScore;
	public static int sheepEatenCount;
	public static int wolfKilledCount;

	public static SheepController sheepLastSpawnedObject;
	public static int sheepMaxSpawnPoints;
	public static GameObject[] sheepLastSpawnPoints;

	public static int currentNumberOfWolves;

	public static Camera mainCamera;
	public static float screenSizeX;
	public static float screenSizeY;



	public static int map(int x, int in_min, int in_max, int out_min, int out_max){
		return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
	}
	public static float mapF(float x, float in_min, float in_max, float out_min, float out_max){
		return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
	}

	public static int constrain(int x, int in_min, int in_max){
		return ( Mathf.Max( Mathf.Min(x, in_max), in_min ) );
	}
	public static float constrainF(float x, float in_min, float in_max){
		return ( Mathf.Max( Mathf.Min(x, in_max), in_min ) );
	}

	
	// =====================================
	// global functions (relating to global data)


	public static void SheepRaptured(){
		GameGlobals.sheepRapturedCount++;
		GameGlobals.CalculateHighScore ();
		GameGlobals.IncreaseGameDifficulty ();
		GameGlobals.EnergyLevel_SheepAscend ();
	}

	public static void CalculateHighScore(){
		if(GameGlobals.sheepRapturedHighScore < GameGlobals.sheepRapturedCount){
			GameGlobals.sheepRapturedHighScore = GameGlobals.sheepRapturedCount;
			PlayerPrefs.SetInt("HighScore", GameGlobals.sheepRapturedHighScore);
			PlayerPrefs.Save();
		}
	}

	public static void EnergyLevel_SheepAscend(){
		energyLevel = constrain( 
		                        energyLevel + energyUpFromSheep + energyDownFromBlast, 
		                        energyLevelRange[0], 
		                        energyLevelRange[1] );
	}

	public static void EnergyLevel_Blast(){
		//Debug.Log ("EnergyLevel_Blast");
		GameObject energyBar = GameObject.Find ("energy bar inner");
		energyBar.GetComponent<Animator>().SetBool( "blast", true );
		energyLevel = constrain( 
		                        energyLevel - energyDownFromBlast, 
		                        energyLevelRange[0], 
		                        energyLevelRange[1] );
	}

	public static void EnergyLevel_WolfAttack(){
		//
		GameObject energyBar = GameObject.Find ("energy bar inner");
		energyBar.GetComponent<Animator>().SetBool( "damage", true );

		energyLevel = constrain( 
		                        energyLevel - energyDownFromWolfAttack, 
		                        energyLevelRange[0], 
		                        energyLevelRange[1] );
	}

	public static void SetGameDifficulty(string level){
		if (level == "easy") {
			gameDifficulty = defaultGameDifficulty_easy;
		} else if (level == "medium") {
			gameDifficulty = defaultGameDifficulty_medium;
		} else if (level == "hard") {
			gameDifficulty = defaultGameDifficulty_hard;
		}
	}


	public static void ResetForNewGame(){
		//
		GameGlobals.sheepRapturedHighScore = PlayerPrefs.GetInt ("HighScore");
		// 
		sheepRapturedCount = 0;
		sheepEatenCount = 0;
		wolfKilledCount = 0;
	}


	public static void UpdateGameDifficulty(){

		wolfSpawnRate = mapF(gameDifficulty, 
		                     gameDifficultyRange[0], gameDifficultyRange[1], 
		                     wolfSpawnRateRange[0], wolfSpawnRateRange[1]);
		
		wolfMoveSpeed = map(gameDifficulty, 
		                     gameDifficultyRange[0], gameDifficultyRange[1], 
		                     wolfMoveSpeedRange[0], wolfMoveSpeedRange[1]);
		
		sheepSpawnSpeed = mapF(gameDifficulty, 
		                     gameDifficultyRange[0], gameDifficultyRange[1], 
		                     sheepSpawnSpeedRange[0], sheepSpawnSpeedRange[1]);
		
		sheepMoveSpeed = map(gameDifficulty, 
		                     gameDifficultyRange[0], gameDifficultyRange[1], 
		                     sheepMoveSpeedRange[0], sheepMoveSpeedRange[1]);

	}



	public static void IncreaseGameDifficulty(){
		//Debug.Log("IncreaseGameDifficulty");
		gameDifficulty += gameDifficultyRampSpeed;
		UpdateGameDifficulty ();
		//Invoke ("IncreaseGameDifficulty", gameDifficultyIncreaseRate);
	}


	
}
