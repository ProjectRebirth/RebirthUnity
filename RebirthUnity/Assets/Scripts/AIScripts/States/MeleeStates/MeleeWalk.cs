using UnityEngine;
using System.Collections;

public class MeleeWalk : State {
	private MeleeStateMachine meleeStateMachine;
	private float destination;
	private TribeMechanics mechanics;
	private bool beganLeft;

	public MeleeWalk(StateMachine stateMachine) : base(stateMachine) {
		meleeStateMachine = (MeleeStateMachine)stateMachine;
		mechanics = meleeStateMachine.mechanics;

	}

	public override void enterState() {
		Collider2D collider = meleeStateMachine.scoutCollider;
		float checkDistance = mechanics.transform.position.x - collider.transform.position.x;

		if (checkDistance < 0) {
			destination = collider.transform.position.x + collider.bounds.size.x / 2.0f;
			beganLeft = true;
		} else {
			destination = collider.transform.position.x - collider.bounds.size.x / 2.0f;
			beganLeft = false;
		}
	}

	public override void exitState() {

	}

	public override void updateState(float deltaTime) {
		if (beganLeft) {
			if (mechanics.transform.position.x > destination) {
				meleeStateMachine.changeState (new MeleeIdle (meleeStateMachine));
			} else {
				mechanics.moveHorizontal (1);
			}

		} else {
			if (mechanics.transform.position.x < destination) {
				meleeStateMachine.changeState (new MeleeIdle(meleeStateMachine));
			} else {
				mechanics.moveHorizontal(-1);
			}
		}
	}

	public override void handleEnterCollider(Collider2D collider) {

	}

	public override void handleExitCollider(Collider2D collider) {

	}
}
