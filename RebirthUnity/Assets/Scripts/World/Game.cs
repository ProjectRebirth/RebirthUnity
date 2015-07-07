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
	}
	
	void Start(){
		Debug.Log("Started!");
		// You define all the game states on SimpleGameManager.cs class
		GM.SetGameState(GameState.GAME);
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.P)) {
			PauseGame();
		}
		if (Input.GetKeyDown (KeyCode.C)) {
			Credits();
		}
	}
	
	public void HandleOnStateChange(){
		Debug.Log("State change called!");
	}
	public void LoadLevel(){
		Debug.Log ("Invoking LoadLevel");
	}

	public void PauseGame(){
		//start game scene
		GM.SetGameState(GameState.PAUSED);
		Debug.Log(GM.gameState);
		Application.LoadLevel ("Paused");
	}
	public void Credits(){
		//start game scene
		GM.SetGameState(GameState.CREDITS);
		Debug.Log(GM.gameState);
		Application.LoadLevel ("Credits");
	}
}