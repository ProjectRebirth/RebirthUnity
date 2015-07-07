using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour {
	
	GameManager GM;
	
	void Awake () {
		GM = GameManager.Instance;
	}
	
	void Start () {
		GM.SetGameState(GameState.INTRO);
		Invoke("LoadLevel", 3f);
	}
	
	public void LoadLevel(){

		Application.LoadLevel("Menu");
	}
}