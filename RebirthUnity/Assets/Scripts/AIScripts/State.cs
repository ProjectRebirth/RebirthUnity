using UnityEngine;
using System.Collections;

//Not implemented
public abstract class State {
	private StateMachine stateMachine;//The state machine that is associated with the sprite

	public State(StateMachine stateMachine) {
		this.stateMachine = stateMachine;
	}

	public abstract void handleEnterCollider(Collider2D collider);

	public abstract void handleExitCollider(Collider2D collider);

	public abstract void enterState ();

	public abstract void updateState (float deltaTime);

	public abstract void exitState();

	public void setStateMachine(StateMachine stateMachine) {
		this.stateMachine = stateMachine;
	}
}
