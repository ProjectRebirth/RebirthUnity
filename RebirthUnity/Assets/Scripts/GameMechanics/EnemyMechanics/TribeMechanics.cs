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


	/**
	 * Updates the Spritemechanics and checks if the sprite is attacking at a particular moment
	 */ 
	protected override void Update() {
		base.Update ();
		isAttacking = checkIsAttacking ();
	}

	/**
	 * Retireves the animator associated witht the sprite. Typically all enemies should have this
	 * component. Also refrences the SpriteMechanics Start() function.
	 */ 
	protected override void Start() {
		base.Start ();
		animator = GetComponent<Animator> ();


	}

	/**
	 * Returns the animator that associated with this sprite.
	 */ 
	public Animator getAnimator() {
		return animator;
	}
	
	/**
	 * Checks to see if the sprite is currently in the attacking animation.
	 */ 
	private bool checkIsAttacking () {
		AnimatorStateInfo currentAnimation = animator.GetCurrentAnimatorStateInfo (0);
		return currentAnimation.IsName (attackAnimation);
	}

	/**
	 * Activates the attack logic for the sprite if the conditions are met to carry out this action.
	 */ 
	public virtual void attack(bool attackButton) {
		if (checkCanAttack()) {
			canAttack = attackButton;
		} else {
			canAttack = false;
		}
	}


	/**
	 * Checks if the enemy can attack in this frame... unfortunately, this lasts for up to 2 or 3 framse at times, so other
	 * checks are necessary to make sure that you're character does not look silly when attacking.
	 */ 
	public bool getCanAttack() {
		return canAttack;
	}

	/**
	 * Checks to make sure that all the conditions are met to carry out an attack action.
	 */
	protected virtual bool checkCanAttack () {
		return !getIsRunning () && !getInAir () && !isAttacking;
	}

	/**
	 * Sets the canAttack variable. Might be useful.... haven't found a use for it yet.
	 */
	public void setCanAttack(bool canAttack) {
		this.canAttack = canAttack;
	}

	/**
	 * Returns whether the sprite is attacking or not.
	 */ 
	public bool getIsAttacking() {
		return isAttacking;
	}

	/**
	 * This is where the knockback logic will be for the game
	 */ 
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
