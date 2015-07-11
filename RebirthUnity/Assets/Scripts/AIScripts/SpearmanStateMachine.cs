using UnityEngine;
using System.Collections;

public class SpearmanStateMachine : StateMachine {
	private Collider2D target;
	public SpearmanMechanics spearmanMechanics;
	public SpearmanStats spearmanStats;
	public string enemyTag;
	public float delayDefend;
	public float delayCharge;//The amount of time the spearman will wait before charging at the player

	public override void beginInitialState() {
		currentState = new SpearmanIdle (this);
	}

	public Collider2D getTarget() {
		return target;
	}

	public void setTarget(Collider2D collider) {
		this.target = collider;
	}
}
