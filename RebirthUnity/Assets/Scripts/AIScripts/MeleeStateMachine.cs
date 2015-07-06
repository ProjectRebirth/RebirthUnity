using UnityEngine;
using System.Collections;

public class MeleeStateMachine : StateMachine {
	public string hostileTag;//This is the variable that the AI will be agressive towards.
	public Collider2D scoutCollider;
	public float attackDistance;
	public float interestCount;
	public float maxWaitTime;
	public float minWaitTime;//This is used to determine how long the sprite should wait
							 //at a specific position during their patrol
	//private float scoutDistance;//This refers to the distance that the sprite will investigate
	public TribeMechanics mechanics;
	private Transform target;


	protected override void Start() {
		base.Start ();
	}

	public override void beginInitialState() {
		currentState = new MeleeIdle (this);
	}

	public void setTarget(Transform target) {
		this.target = target;
	}

	public Transform getTarget() {
		return target;
	}

	public TribeMechanics getMechanics() {
		return (TribeMechanics)mechanics;
	}
}
