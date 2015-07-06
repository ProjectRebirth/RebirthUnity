using UnityEngine;
using System.Collections;

public class SkeletonIdle : State {
	private SkeletonStateMachine skeletonStateMachine;

	public SkeletonIdle(StateMachine stateMachine) : base(stateMachine) {

	}

	public override void enterState() {

	}

	public override void exitState() {

	}

	public override void updateState(float deltaTime) {


	}

	public override void handleExitCollider(Collider2D collider) {

	}

	public override void handleEnterCollider(Collider2D collider) {
		skeletonStateMachine.setTarget (collider.transform);
	}

}
