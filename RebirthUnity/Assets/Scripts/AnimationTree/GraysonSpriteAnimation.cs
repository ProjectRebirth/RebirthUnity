using UnityEngine;
using System.Collections;


/**
 * This script helps to switch animations accordingly for the sprite.
 * It is currently set up for Grayson only, but we can make a
 * generic Animator in the furure to apply to multiple sprites with similar animations
 */ 
public class GraysonSpriteAnimation : MonoBehaviour {
	public Animator legAnimator;//The animator that controls the leg animation
	public Animator torsoAnimator;//The animator that controls the torsanimation
	public float bobbingIntensity;//How much our character will move up and down

	/**
	 * Updates all animation parameters for the Animator
	 * This currently checks if Grayson is moving
	 * Or if he is falling. All logic for animations should
	 * go here.
	 */ 
	void Update() {
		legAnimator.SetBool("inAir", checkInAir());
		legAnimator.SetBool ("isRunning", checkIsRunning());

		if (Input.GetKey(KeyCode.R)){

			torsoAnimator.SetTrigger("reloadTrigger");
		}
		bobSprite ();
	}


	private void bobSprite() {
		if (!legAnimator.GetBool ("inAir") && legAnimator.GetBool ("isRunning")) {

		}
	}




	/*
	 *Quick check to see if the player is moving on across the screen based 
	 *on his horizontal movement.
	 */
	private bool checkIsRunning() {
		Rigidbody2D rigid = GetComponent<Rigidbody2D> ();
		float x = rigid.velocity.x;
		return Mathf.Abs (x) > 0f;
	}

	/*
	 * Quick check to see if the player is in the air based on his vertical
	 * movement
	 */ 
	private bool checkInAir() {
		Rigidbody2D rigid = GetComponent<Rigidbody2D> ();
		float y = rigid.velocity.y;
		return Mathf.Abs(y) > 0f;
	}
}


