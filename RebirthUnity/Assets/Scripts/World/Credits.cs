using UnityEngine;
using System.Collections;

public class Credits: MonoBehaviour {
	
	GameManager GM;
	
	void Awake () {
		GM = GameManager.Instance;
	}
	
	void Start(){

	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.V)) {
			returnToGame();
		}
	}

	public void returnToGame(){
		GM.SetGameState(GameState.GAME);
		Application.LoadLevel ("Level1");
	}

}