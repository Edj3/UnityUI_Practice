using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartGameScript : MonoBehaviour {
	//Variable Declarations
	public static Text startGameText;
	public static bool gameStarted = false;

	// Use this for initialization
	void Start () {
		//Grab the text of the bottom in case you want to change it
		startGameText = this.gameObject.GetComponentInChildren<Text>();
		if(GameManager.uiCount > 0){
			startGameText.text = "Resume Game";
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void StartGame(){
		//Set gameStarted to true
		gameStarted = true;

		//Change the text
		GameManager.DontDestroyOnLoad ();
		//If a sphere exists, you know that the game has already been started, therefore you just need to destroy the UI & not reload the scene
		if (GameObject.Find ("Super Sphere") == null) {
			//Load the level while destroying the UI the first time the user starts the game
			Application.LoadLevel(1);
			Debug.Log("The Game has begun!");
		} else {
			//manually destroy the Title Screen UI Objects in the case that the game has already been started
			DontDestroyOnLoad(startGameText);
			Destroy (GameObject.Find("TitleScreenUI"));
			Debug.Log("The Game has been resumed!");
			GameManager.ResumeGame();
		}
		//reset the UI Count so that it does not copy itself upon reinstantiation
		GameManager.uiCount = 0;
	}
}
