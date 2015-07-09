using UnityEngine;
using System.Collections;

public class SpearmanDefend : State {
	SpearmanStateMachine spearStateMachine;

	public SpearmanDefend(StateMachine stateMachine) : base(stateMachine) {
		spearStateMachine = (SpearmanStateMachine)stateMachine;

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
}
