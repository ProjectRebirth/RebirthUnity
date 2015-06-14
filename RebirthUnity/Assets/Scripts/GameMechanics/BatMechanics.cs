using UnityEngine;
using System.Collections;

public class BatMechanics : SpriteMechanics {
	public float verticalSpeed;
	public Animator animator;
	public string deathAnimation;

	protected override void isDeadCleanup() {
		if (getIsDead ()) {
			Rigidbody2D rigid = GetComponent<Rigidbody2D>();
			rigid.gravityScale = 1;
			AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

			if (getInAir() && stateInfo.IsName(deathAnimation) && stateInfo.normalizedTime > .05){
				animator.enabled = false;
			}
			else animator.enabled = true;
		}
	}

	public override void moveVertical(float verticalInput) {
		Rigidbody2D rigid = GetComponent<Rigidbody2D> ();
		float x = rigid.velocity.x;
		float y = verticalInput * verticalSpeed;
		if (!getIsDead ()) {
			rigid.velocity = new Vector2 (x, y);
		}
	}
}
