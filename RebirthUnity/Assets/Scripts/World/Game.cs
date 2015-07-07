using UnityEngine;
using System.Collections;

public class Game: MonoBehaviour {
	public Font tech;
	GameManager GM;
	
	void Awake () {
		GM = GameManager.Instance;
	}
	
	void Start(){
		GM.SetGameState(GameState.GAME);
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.P)) {
			PauseGame();
		}
		if (Input.GetKeyDown (KeyCode.Q)) {
			ResumeGame();
		}
		if (Input.GetKeyDown (KeyCode.C)) {
			Credits();
		}
	}
	public void OnGUI(){
		//menu layout
		GUI.BeginGroup (new Rect (Screen.width / 2 - 145 , Screen.height / 2 - 150, 340, 800));
		GUI.backgroundColor = Color.white;
		GUI.skin.font = tech;
		GUI.skin.label.fontSize = 48;
		if (GUI.Button (new Rect (0, 0, 290, 60), "New Game")){
		}
		if (GUI.Button (new Rect (0,80, 290, 60), "Load Game")){
		}
		if (GUI.Button (new Rect (0,160, 290, 60), "Credits")){
		}
		if (GUI.Button (new Rect (0,240 , 290, 60), "Quit")){
		}
		GUI.EndGroup();
	}

	
	public void PauseGame(){
		Time.timeScale  = 0;
	}
	public void ResumeGame(){
		Time.timeScale  = 1;
	}

	public void Credits(){
		GM.SetGameState(GameState.CREDITS);
		Application.LoadLevel ("Credits");
	}
}