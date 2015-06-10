using UnityEngine;
using System.Collections;

public class MeleeEnemyAnimations : MonoBehaviour {
	public SpriteMechanics meleeMechanics;
	public Animator animator;
	
	void Update() {
		animator.SetBool ("isRunning", meleeMechanics.getIsRunning ());
		//animator.SetBool ("isAttacking", meleeMechanics.getIsAttacking ());
		animator.SetBool ("inAir", meleeMechanics.getInAir ());
	}

	void FixedUpdate() {

	}

	void Start() {

	}
	
}
