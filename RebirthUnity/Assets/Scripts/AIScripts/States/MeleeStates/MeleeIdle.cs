using UnityEngine;
using System.Collections;

public class MeleeIdle : State {

	public MeleeIdle(StateMachine stateMachine) : base(stateMachine){

	}

	public override void enterState ()
	{
		throw new System.NotImplementedException ();
	}

	public override void exitState() {

	}

	public override void updateState(float deltaTime) {

	}

	public override void handleExitCollider (Collider2D collider)
	{

	}

	public override void handleEnterCollider (Collider2D collider) {

	}
}
