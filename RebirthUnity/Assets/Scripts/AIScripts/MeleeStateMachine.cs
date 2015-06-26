using UnityEngine;
using System.Collections;

public class MeleeStateMachine : StateMachine {
	public string hostileTag;//This is the variable that the AI will be agressive towards.
	public Collider2D scoutCollider;
	public TribeMechanics mechanics;
	public float attackDistance;
	public float interestCount;
	public float maxWaitTime;
	public float minWaitTime;//This is used to determine how long the sprite should wait
							 //at a specific position during their patrol
	//private float scoutDistance;//This refers to the distance that the sprite will investigate
	private Transform target;


	protected override void Start() {
		base.Start ();
	}

	public override void beginIdleState() {
		currentState = new MeleeIdle (this);
	}

	public void setTarget(Transform target) {
		this.target = target;
	}

	public Transform getTarget() {
		return target;
	}
}
