using UnityEngine;
using System.Collections;

public class MeleeIdle : State {
	private float waitTime;
	private MeleeStateMachine meleeStateMachine;//This is more specifically connected the MeleeStateMachine



	public MeleeIdle(StateMachine stateMachine) : base(stateMachine){
		this.meleeStateMachine = (MeleeStateMachine)stateMachine;
	}

	public override void enterState ()
	{
		waitTime = Random.Range (meleeStateMachine.minWaitTime, meleeStateMachine.maxWaitTime);

	}

	public override void exitState() {

	}

	public override void updateState(float deltaTime) {
		waitTime -= deltaTime;
		if (waitTime < 0) {
			meleeStateMachine.changeState (new MeleeWalk(meleeStateMachine));
		}
	}

	public override void handleExitCollider (Collider2D collider)
	{
		if (collider.tag == meleeStateMachine.hostileTag) {
			meleeStateMachine.setTarget(collider.transform);
			meleeStateMachine.changeState (new MeleeAggro(meleeStateMachine));
		}
	}

	public override void handleEnterCollider (Collider2D collider) {
		if (collider.tag  == meleeStateMachine.hostileTag) {

		}
	}
}
