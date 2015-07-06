using UnityEngine;
using System.Collections;

public class Game: MonoBehaviour {
	
	GameManager GM;
	
	void Awake () {
		// call the instance 
		GM = GameManager.Instance;
		// add a callback for when the game state changes
		GM.OnStateChange += HandleOnStateChange;
		Debug.Log("Current game state when Awakes: " + GM.gameState);
		if (Input.GetKeyDown (KeyCode.P)){
			GM.SetGameState(GameState.PAUSED);
		}
	}
	
	void Start(){
		Debug.Log("Started!");
		// You define all the game states on SimpleGameManager.cs class
		GM.SetGameState(GameState.GAME);
	}
	
	public void HandleOnStateChange(){
		Debug.Log("State change called!");
	}
	public void LoadLevel(){
		Debug.Log("Invoking LoadLevel");
		Application.LoadLevel("Level1");
	}
}