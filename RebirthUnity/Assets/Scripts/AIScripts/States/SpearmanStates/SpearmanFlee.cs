using UnityEngine;
using System.Collections;

public class SpearmanFlee : State {
	SpearmanStateMachine spearStateMachine;

	public SpearmanFlee(StateMachine stateMachine) : base (stateMachine) {
		spearStateMachine = (SpearmanStateMachine)spearStateMachine;
	}

	public override void enterState() {

	}

	public override void exitState() {

	}

	public override void updateState(float deltaTime) {

	}

	public override void handleEnterCollider(Collider2D collider) {

	}

	public override void handleExitCollider(Collider2D collider) {

	}

	private float getDeltaX() {
		float goalX = 
	}

}
