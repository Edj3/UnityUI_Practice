using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {
	//initialize Canvas object to hold start menu
	public Canvas startMenuCanvas;
	public static bool isGamePaused = false;
	public static GameObject gameManagerObject;
	public static int uiCount = 0;

	//Create function to handle destruction of game manager objects across classes and scripts!
	public static void DontDestroyOnLoad(){
		DontDestroyOnLoad (gameManagerObject);
	}

	// Use this for initialization
	void Start () {
		gameManagerObject = this.gameObject;
		//Force the screen into Landscape on start of game
		Screen.orientation = ScreenOrientation.LandscapeLeft;
	}

	// Update is called once per frame
	void Update () {
		//If the cancel or escape button is pressed, bring up the start menu
		if(Input.GetButton("Cancel") && uiCount < 1 && StartGameScript.gameStarted == true){
			isGamePaused = togglePause();
			Destroy(gameManagerObject);
			Application.LoadLevelAdditive(0);
			Debug.Log ("Level Should have Loaded");
			uiCount++;
		}

		SetupScreen ();

	}

	//Function to handle screen orientation for mobile devices
	void SetupScreen(){
		if(Input.deviceOrientation == DeviceOrientation.LandscapeLeft )
		{
			Screen.orientation = ScreenOrientation.LandscapeLeft;
		}
		else if(Input.deviceOrientation == DeviceOrientation.LandscapeRight )
		{
			Screen.orientation = ScreenOrientation.LandscapeRight;
		}
	}

	public static void ResumeGame (){
		isGamePaused = togglePause ();
	}

	public static bool togglePause()
	{
		if(Time.timeScale == 0f)
		{
			Time.timeScale = 1f;
			return(false);
		}
		else
		{
			Time.timeScale = 0f;
			return(true);    
		}
	}
}
