using UnityEngine;
using System.Collections;

public class SpearmanIdle : State {
	SpearmanStateMachine spearStateMachine;

	public SpearmanIdle(StateMachine stateMachine) : base (stateMachine) {
		this.spearStateMachine = (SpearmanStateMachine)stateMachine;
	}

	public override void enterState (){

	}

	public override void exitState() {

	}
	public override void updateState(float deltaTime) {

	}

	public override void handleEnterCollider(Collider2D collider) {
		if (collider.tag == spearStateMachine.enemyTag) {
			spearStateMachine.setTarget (collider);
			spearStateMachine.changeState (new SpearmanDefend (spearStateMachine));
		}
	}

	public override void handleExitCollider(Collider2D collider) {

	}

}
