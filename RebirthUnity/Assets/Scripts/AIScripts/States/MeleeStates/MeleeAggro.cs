using UnityEngine;
using System.Collections;

public class MeleeAggro : State {
	private MeleeStateMachine meleeStateMachine;
	private Transform target;//This will represent the target that the AI is currently supposed to attack
	private float attackDistance;
	private float interestCount;//This variable refers to when an NPC will lose interest in their target
	private Vector3 lastKnownPoint;//This variable refers to the location of the targetted sprite or object
	private bool inSight;//This variable refers to whether or not the target is in sight of the AI


	public MeleeAggro(StateMachine stateMachine): base(stateMachine){
		this.meleeStateMachine = (MeleeStateMachine)stateMachine;

	}

	public override void updateState(float deltaTime) {
		TribeMechanics mechanics = meleeStateMachine.mechanics;
		if (inSight) {
			lastKnownPoint = target.position;
		}
		checkTargetInSight (deltaTime);
		moveTowardsTarget (mechanics);


	}

	private void moveTowardsTarget(TribeMechanics mechanics) {
		float meleeX = meleeStateMachine.transform.position.x;
		float targetX = lastKnownPoint.x;

		float distanceX = meleeX - targetX;//If this is negative, then move to the right

		if (Mathf.Abs (distanceX) < attackDistance) {
			if (inSight) {
				mechanics.attack (true);
			}
		} else if (distanceX < 0) {
			mechanics.moveHorizontal(1);
		} else {
			mechanics.moveHorizontal(-1);
		}
	}

	private void checkTargetInSight(float deltaTime) {
		if (!inSight) {
			interestCount -= deltaTime;
		}

		if (interestCount < 0) {
			meleeStateMachine.changeState (new MeleeWalk(meleeStateMachine));
		}
	}

	public override void enterState() {
		target = meleeStateMachine.getTarget ();
		attackDistance = meleeStateMachine.attackDistance;
		interestCount = meleeStateMachine.interestCount;
		inSight = true;
	}

	public override void exitState() {

	}

	public override void handleEnterCollider(Collider2D collider) {
		if (collider.tag == meleeStateMachine.hostileTag) {
			inSight = true;
		}
	}

	public override void handleExitCollider (Collider2D collider) {
		if (collider.tag == meleeStateMachine.hostileTag) {
			inSight = false;
		}
	}

}
