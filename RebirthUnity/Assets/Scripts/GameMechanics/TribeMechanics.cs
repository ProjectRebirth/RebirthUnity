using UnityEngine;
using System.Collections;

public class TribeMechanics : SpriteMechanics {
	private bool isAttacking;
	private bool canAttack;
	private bool isAggressive;
	private bool graysonInView;
	
	private float aggressiveCoolDown;
	
	private Animator animator;
	public string attackAnimation;
	
	
	protected override void Update() {
		base.Update ();
		isAttacking = checkIsAttacking ();
	}
	
	protected override void Start() {
		base.Start ();
		animator = GetComponent<Animator> ();


	}

	public Animator getAnimator() {
		return animator;
	}
	
	
	private bool checkIsAttacking () {
		AnimatorStateInfo currentAnimation = animator.GetCurrentAnimatorStateInfo (0);
		return currentAnimation.IsName (attackAnimation);
	}
	
	public virtual void attack(bool attackButton) {
		if (checkCanAttack()) {
			canAttack = attackButton;
		} else {
			canAttack = false;
		}
	}
	
	public bool getCanAttack() {
		return canAttack;
	}
	
	protected virtual bool checkCanAttack () {
		return !getIsRunning () && !getInAir () && !isAttacking;
	}
	
	public void setCanAttack(bool canAttack) {
		this.canAttack = canAttack;
	}
	
	public bool getIsAttacking() {
		return isAttacking;
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
