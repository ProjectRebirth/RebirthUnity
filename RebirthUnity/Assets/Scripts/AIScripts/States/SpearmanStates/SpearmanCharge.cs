using UnityEngine;
using System.Collections;

public class SpearmanCharge : State {

	private SpearmanStateMachine spearStateMachine;
	private Vector3 chargeLocation;
	private float minChargeDistance;//This is the minimum distance the spearman should stay away from a character

	public SpearmanCharge(StateMachine stateMachine) : base(stateMachine) {
		spearStateMachine = (SpearmanStateMachine)stateMachine;
	}

	public override void enterState() {
		Collider2D target = spearStateMachine.getTarget ();
		chargeLocation = target.transform.position;
		float deltaX = getDeltaX ();
		if (Mathf.Abs (deltaX) < minChargeDistance) {
			spearStateMachine.changeState (new SpearmanFlee(spearStateMachine));
		}
	}

	public override void exitState() {

	}

	public override void updateState(float deltaTime) {
		float deltaX = getDeltaX ();
	}

	public override void handleEnterCollider(Collider2D collider) {

	}

	public override void handleExitCollider(Collider2D collider) {

	}

	private float getDeltaX() {
		float goalX = chargeLocation.x;
		float currentX = spearStateMachine.transform.position.x;
		return currentX - goalX;
	}
}
