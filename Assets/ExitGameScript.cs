using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ExitGameScript : MonoBehaviour {
	public static Text exitGameText;

	// Use this for initialization
	void Start () {
		exitGameText = gameObject.GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void ExitGame(){
		StartCoroutine(ExitGameCoroutine());
	}

	public IEnumerator ExitGameCoroutine(){
		//Quit the game
		exitGameText.text = "Game Over.";
		Debug.Log("Exit Game Delay Coroutine");
		yield return null;

		//Destroy Scenes
		Destroy (GameObject.Find ("AllGameObjects"));
		Destroy (GameObject.Find("TitleScreenUI"));
		Application.Quit ();
		Debug.Log ("The user has officially quit the game");
	}
}
