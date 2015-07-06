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
	
	public void HandleOnStateChange(){
		Debug.Log("State change called!");
		Application.LoadLevel("Paused");
	}
}