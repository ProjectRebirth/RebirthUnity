using UnityEngine;
using System.Collections;

public class Paused: MonoBehaviour {
	
	GameManager GM;
	
	void Awake () {
		// call the instance 
		GM = GameManager.Instance;
		// add a callback for when the game state changes
		GM.OnStateChange += HandleOnStateChange;
		Debug.Log("Current game state when Awakes: " + GM.gameState);
	}
	
	void Start(){
		Debug.Log("Started!");
		// You define all the game states on SimpleGameManager.cs class
		GM.SetGameState(GameState.PAUSED);
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Q)) {
			ResumeGame();
		}
		if (Input.GetKeyDown (KeyCode.C)) {
			Credits();
		}
	}
	
	public void HandleOnStateChange(){
		Debug.Log("State change called!");
		Application.LoadLevel("Paused");
	}

	public void ResumeGame(){
		//start game scene
		GM.SetGameState(GameState.GAME);
		Debug.Log(GM.gameState);
		Application.LoadLevel ("Level1");
	}
	public void Credits(){
		//start game scene
		GM.SetGameState(GameState.CREDITS);
		Debug.Log(GM.gameState);
		Application.LoadLevel ("Credits");
	}
}