using UnityEngine;
using System.Collections;

public class MeleeStateMachine : StateMachine {
	public Collider2D scoutCollider;
	public TribeMechanics mechanics;
	public float maxWaitTime;
	public float minWaitTime;//This is used to determine how long the sprite should wait
							 //at a specific position during their patrol
	//private float scoutDistance;//This refers to the distance that the sprite will investigate


	protected override void Start() {
		base.Start ();
	}

	public override void beginIdleState() {
		currentState = new MeleeIdle (this);
	}

}
