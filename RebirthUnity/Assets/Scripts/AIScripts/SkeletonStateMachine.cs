using UnityEngine;
using System.Collections;

public class SkeletonStateMachine : StateMachine {
	Transform target{ get; set; }
	public SpriteMechanics mechanics { get; set; }

	public SkeletonMechanics getSkeletonMechanics() {
		return (SkeletonMechanics)mechanics;
	}

	public override void beginInitialState() {

	}

	public void setTarget(Transform target) {
		this.target = target;
	}

	public Transform getTarget() {
		return target;
	}
}
