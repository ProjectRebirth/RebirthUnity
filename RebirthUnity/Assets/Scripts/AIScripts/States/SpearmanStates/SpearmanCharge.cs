using UnityEngine;
using System.Collections;

public class SpearmanCharge : State {

	private SpearmanStateMachine spearStateMachine;
	private SpearmanMechanics spearmanMechanics;
	private Vector3 chargeLocation;
	private GraysonMechanics targetEnemy;
	private float minChargeDistance;//This is the minimum distance the spearman should stay away from a character

	public SpearmanCharge(StateMachine stateMachine) : base(stateMachine) {
		spearStateMachine = (SpearmanStateMachine)stateMachine;
	}

	public override void enterState() {
		targetEnemy = spearStateMachine.getTarget ().GetComponent<GraysonMechanics> ();
		chargeLocation = targetEnemy.transform.position;
		spearmanMechanics = spearStateMachine.spearmanMechanics;

	}

	public override void exitState() {

	}

	public override void updateState(float deltaTime) {
		float deltaX = getDeltaX ();
		if (deltaX > 1) {
			spearmanMechanics.moveHorizontal (-1);
		} else if (deltaX < -1) {
			spearmanMechanics.moveHorizontal(1); 
		}
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
