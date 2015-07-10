using UnityEngine;
using System.Collections;

public class SpearmanDefend : State {
	SpearmanStateMachine spearStateMachine;
	SpearmanMechanics spearMechanics;
	GraysonMechanics targetEnemy;//This should never be null, unless Grayson dies...
	float delayDefend;
	float delayDefendCounter;


	public SpearmanDefend(StateMachine stateMachine) : base(stateMachine) {
		spearStateMachine = (SpearmanStateMachine)stateMachine;
		delayDefend = spearStateMachine.delayDefend;
		delayDefendCounter = delayDefend;

	}

	public override void enterState() {
		spearMechanics = spearStateMachine.spearmanMechanics;
		targetEnemy = spearStateMachine.getTarget ().GetComponent<GraysonMechanics>();
	}

	public override void exitState() {
		spearMechanics.defend (false);
	}

	public override void updateState(float deltaTime) {
		if (targetEnemy.getIsFiring ()) {

		}
		if (targetEnemy.getIsReloading ()) {
			spearMechanics.defend (false);
			spearStateMachine.changeState (new SpearmanCharge(spearStateMachine));
		}
		if (delayDefendCounter <= 0) {
			delayDefendCounter = 0f;
			spearMechanics.defend (true);
		} else {
			spearMechanics.defend(false);
		}
		delayDefendCounter -= deltaTime;
	}

	public override void handleEnterCollider(Collider2D collider) {

	}

	public override void handleExitCollider(Collider2D collider) {

	}
}
