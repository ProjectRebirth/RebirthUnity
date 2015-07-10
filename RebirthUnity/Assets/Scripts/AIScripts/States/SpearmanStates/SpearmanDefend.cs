using UnityEngine;
using System.Collections;

public class SpearmanDefend : State {
	SpearmanStateMachine spearStateMachine;
	SpearmanMechanics spearMechanics;
	GraysonMechanics targetEnemy;//This should never be null, unless Grayson dies...


	public SpearmanDefend(StateMachine stateMachine) : base(stateMachine) {
		spearStateMachine = (SpearmanStateMachine)stateMachine;

	}

	public override void enterState() {
		spearMechanics = spearStateMachine.spearmanMechanics;
		targetEnemy = spearStateMachine.getTarget ().GetComponent<GraysonMechanics>();
	}

	public override void exitState() {
		spearMechanics.defend (false);
	}

	public override void updateState(float deltaTime) {
		spearMechanics.defend (true);
		if (targetEnemy.getIsReloading ()) {
			spearStateMachine.changeState (new SpearmanCharge(spearStateMachine));
		}

	}

	public override void handleEnterCollider(Collider2D collider) {

	}

	public override void handleExitCollider(Collider2D collider) {

	}
}
