using UnityEngine;
using System.Collections;

public class TribeMechanics : SpriteMechanics {
	private bool isAttacking;
	private bool canAttack;
	private bool isAggressive;
	private bool graysonInView;
	private float aggressiveCoolDown;

	public Animator animator;
	public string attackAnimation;


	protected override void Update() {
		base.Update ();
		isAttacking = checkIsAttacking ();
	}

	protected override void Start() {
		base.Start ();
	}


	private bool checkIsAttacking () {
		AnimatorStateInfo currentAnimation = animator.GetCurrentAnimatorStateInfo (0);
		return currentAnimation.IsName (attackAnimation);
	}

	public void attack(bool attackButton) {
		if (attackButton) {

		}
	}

	void OnTriggerEnter2D (Collider2D collider) {

		if (collider.tag == "Grayson") {
			//GraysonMechanics grayson = collider.GetComponent<GraysonMechanics>();
			Rigidbody2D rigid = collider.GetComponent<Rigidbody2D>();
			if (getIsRight ()) {
				rigid.AddForce(new Vector2 ());
			}
		}
	}

	void OnTriggerExit2D (Collider2D collider) {

	}

}
