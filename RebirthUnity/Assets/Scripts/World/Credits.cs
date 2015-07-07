using UnityEngine;
using System.Collections;

public class Credits: MonoBehaviour {
	
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
		GM.SetGameState(GameState.CREDITS);
	}
	void Update(){
		if (Input.GetKeyDown (KeyCode.V)) {
			returnToGame();
		}
	}
	
	public void HandleOnStateChange(){
		Debug.Log("State change called!");
	}
	public void returnToGame(){
		//start game scene
		GM.SetGameState(GameState.GAME);
		Debug.Log(GM.gameState);
		Application.LoadLevel ("Level1");
	}

}