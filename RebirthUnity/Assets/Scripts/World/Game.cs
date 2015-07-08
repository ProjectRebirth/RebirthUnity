﻿using UnityEngine;
using System.Collections;

public class Game: MonoBehaviour {
	public Font tech;
	public bool pFlag;
	GameManager GM;
	
	void Awake () {
		GM = GameManager.Instance;
	}
	
	void Start(){
		pFlag = false;
		GM.SetGameState(GameState.GAME);

	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.P)) {
			pFlag = !pFlag;
			GUI.enabled = pFlag;
			if(pFlag){
				PauseGame();
			}else{
				ResumeGame ();
			}
		}
	}
	public void OnGUI(){
		GUI.enabled = pFlag;
		/*
		if (pFlag) {
			GUI.color.a = 0;
		} else {
			GUI.color.a = 1;
		}
		*/
		GUI.BeginGroup (new Rect (Screen.width / 2 - 145 , Screen.height / 2 - 150, 340, 800));
		GUI.backgroundColor = Color.white;
		GUI.skin.font = tech;
		if (GUI.Button (new Rect (0, 0, 290, 60), "Resume")){
			pFlag = !pFlag;
			ResumeGame();
		}
		if (GUI.Button (new Rect (0,80, 290, 60), "Option")){
		}
		if (GUI.Button (new Rect (0,160 , 290, 60), "Quit")){
		}
		GUI.EndGroup();
	}
	
	public void PauseGame(){
		Time.timeScale  = 0;
	}
	public void ResumeGame(){
		Time.timeScale  = 1;
	}
}