using UnityEngine;
using System.Collections;

public class MeleeStateMachine : StateMachine {
	public TribeMechanics mechanics;

	public override void beginIdleState() {
		//currentState = new MeleeIdle (this);
	}

}
