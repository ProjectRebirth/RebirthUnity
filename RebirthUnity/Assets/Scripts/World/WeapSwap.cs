using UnityEngine;
using System.Collections;

public class WeapSwap: MonoBehaviour {
	
	GameManager GM;
	
	void Awake () {
		// call the instance 
		GM = GameManager.Instance;
		// add a callback for when the game state changes
		GM.OnStateChange += HandleOnStateChange;
		Debug.Log("Current game state when Awakes: " + GM.gameState);
	}
	
	void Start(){
		Debug.Log("Weapon Swap State!");
		GM.SetGameState(GameState.WEAP_SWAP);
	}
	
	public void HandleOnStateChange(){
		Debug.Log("State change called!");
	}
}