using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour {
	
	GameManager GM;
	
	void Awake () {
		// call the instance 
		GM = GameManager.Instance;
		// add a callback for when the game state changes
		GM.OnStateChange += HandleOnStateChange;
		Debug.Log("Current game state when Awakes: " + GM.gameState);
	}
	
	void Start () {
		Debug.Log("Current game state when Starts: " + GM.gameState);
		GM.SetGameState(GameState.MAIN_MENU);
	}
	
	public void HandleOnStateChange ()
	{
		Debug.Log("Handling state change to: " + GM.gameState);
		Invoke("LoadLevel", 3f);
	}
	
	public void LoadLevel(){
		Debug.Log("Invoking LoadLevel");
		Application.LoadLevel("Menu");
	}
	
	
}