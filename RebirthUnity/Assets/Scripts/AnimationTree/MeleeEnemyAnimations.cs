using UnityEngine;
using System.Collections;

public class MeleeEnemyAnimations : MonoBehaviour {
	public SpriteMechanics meleeMechanics;
	public Animator animator;
	private bool deathAnimationStarted;
	public string deathAnimationName;
	
	void Update() {
		checkIsDead ();
		animator.SetBool ("isRunning", meleeMechanics.getIsRunning ());
		//animator.SetBool ("isAttacking", meleeMechanics.getIsAttacking ());
		animator.SetBool ("inAir", meleeMechanics.getInAir ());
		animator.SetBool ("isDead", meleeMechanics.getIsDead ());

	}

	void checkIsDead() {
		print (deathAnimationStarted);
		AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo (0);
		if (deathAnimationStarted && info.normalizedTime > .5) {
			Destroy(this.gameObject);
		}
		if (info.IsName (deathAnimationName)) {
			deathAnimationStarted = true;
		}

	}

}
