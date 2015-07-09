using UnityEngine;
using System.Collections;

public class SpearmanStateMachine : StateMachine {
	private Collider2D target;
	public SpearmanMechanics spearmanMechanics;
	public SpearmanStats spearmanStats;

	public override void beginInitialState() {

	}

	public Collider2D getTarget() {
		return target;
	}
}
