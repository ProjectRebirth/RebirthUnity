using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	GameManager GM;
	public static string playerPrefab = "/Assets/Prefabs/MapV2";

	void Awake () {
		GM = GameManager.Instance;
		GM.OnStateChange += HandleOnStateChange;
	}
	
	public void HandleOnStateChange ()
	{
		Debug.Log("OnStateChange!");
	}
	
	
	public void OnGUI(){
		//menu layout
		GUI.BeginGroup (new Rect (Screen.width / 2 - 50, Screen.height / 2 - 50, 170, 800));
		GUI.Box (new Rect (0, 0, 170, 200), "Menu");
		if (GUI.Button (new Rect (10, 40, 150, 30), "Start")){
			StartGame();
		}
		if (GUI.Button (new Rect (10, 80, 150, 30), "Instructions")){
			ShowInstructions();
		}
		if (GUI.Button (new Rect (10, 120, 150, 30), "Credits")){
			ShowCredits();
		}
		if (GUI.Button (new Rect (10, 160, 150, 30), "Quit")){
			Quit();
		}
		GUI.EndGroup();
	}
	
	
	public void ShowCredits(){
		// show credits scene or GUI
		GM.SetGameState(GameState.CREDITS);
		Debug.Log(GM.gameState);
		Application.LoadLevel ("Credits");
	}
	
	public void StartGame(){
		//start game scene
		GM.SetGameState(GameState.GAME);
		Debug.Log(GM.gameState);
		Application.LoadLevel ("Level1");
	}
	
	public void ShowInstructions(){
		// show Help scene or GUI
		GM.SetGameState(GameState.INSTRUCT);
		Debug.Log(GM.gameState);
		Application.LoadLevel ("Instructions");
	}
	
	public void Quit(){
		Debug.Log("Quit!");
		Application.Quit();
	}

}