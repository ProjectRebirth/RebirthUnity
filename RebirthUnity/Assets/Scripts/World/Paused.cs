using UnityEngine;
using System.Collections;

public class Paused: MonoBehaviour {
	
	GameManager GM;
	
	void Awake () {
		GM = GameManager.Instance;
	}
	
	void Start(){
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Q)) {
			ResumeGame();
		}
	}

	public void ResumeGame(){
		GM.SetGameState(GameState.GAME);
		Application.LoadLevel ("Level1");
	}

	public void Credits(){
		GM.SetGameState(GameState.CREDITS);
		Application.LoadLevel ("Credits");
	}
}