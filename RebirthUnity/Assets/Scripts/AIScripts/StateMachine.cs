﻿using UnityEngine;
using System.Collections;


/**
 * ALL STATEMACHINES WILL GO INTO THE BRAIN COMPONENT OF ANY SPRITE.
 * IF THERE IS NO BRAIN COMPONENT, PLEASE ADD ONE AND THEN ADD A STATEMACHINE SCRIPT TO THAT
 * INSTEAD OF ADDING IT TO THE MAIN SPRITE OBJECT
 */ 
public abstract class StateMachine : MonoBehaviour {
	//public State[] validStates;
	public State currentState;


	protected virtual void Start() {
		beginInitialState ();
	}

	public abstract void beginInitialState();

	/**
	 * Currently this calls the update in the currentState of the StateMachine
	 */ 
	protected virtual void Update () {

		currentState.updateState (Time.deltaTime);
	}

	/**
	 * This will be where the currentState is updated
	 */ 
	public void changeState(State newState) {
		closeCurrentState ();
		currentState = newState;
		currentState.enterState ();

	}

	private void closeCurrentState() {
		currentState.exitState ();
		currentState = null;
	}

	void OnTriggerEnter2D (Collider2D collider) {
		print ("in StateMachine");
		currentState.handleEnterCollider (collider);

	}

	void OnTriggerExit2D (Collider2D collider) {
		currentState.handleExitCollider (collider);

	}

}
