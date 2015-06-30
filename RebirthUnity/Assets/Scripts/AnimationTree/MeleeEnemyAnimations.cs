using UnityEngine;
using System.Collections;

public class MeleeEnemyAnimations : MonoBehaviour {
	public TribeMechanics meleeMechanics;
	public Animator animator;
	private bool deathAnimationStarted;
	public string deathAnimationName;
	public SpriteStats spriteStats;
	
	void Update() {
		checkIsDead ();
		animator.SetBool ("isRunning", meleeMechanics.getIsRunning ());//animator.SetBool ("isAttacking", meleeMechanics.getIsAttacking ());
		animator.SetBool ("isAttacking", meleeMechanics.getCanAttack ());
		animator.SetBool ("inAir", meleeMechanics.getInAir ());
		animator.SetBool ("isDead", spriteStats.getIsDead());

	}

	void checkIsDead() {
		AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo (0);
		if (deathAnimationStarted && info.normalizedTime > .8) {
			Destroy(this.gameObject);
		}
		if (info.IsName (deathAnimationName)) {
			deathAnimationStarted = true;
		}
	}

}
