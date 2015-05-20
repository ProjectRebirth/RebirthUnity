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


	//The variables below are for the bobbing animation
	public Transform torso;
	private Vector2 torsoOrigin;
	

	void Start() {
		torsoOrigin = new Vector2 (torso.localPosition.x, torso.localPosition.y);
	}

	/**
	 * Updates all animation parameters for the Animator
	 * This currently checks if Grayson is moving
	 * Or if he is falling. All logic for animations should
	 * go here.
	 */ 
	void Update() {
		AnimatorStateInfo animationInfo = torsoAnimator.GetCurrentAnimatorStateInfo (0);


		bool inAir = checkInAir ();
		bool isRunning = checkIsRunning ();

		legAnimator.SetBool("inAir", inAir);
		legAnimator.SetBool ("isRunning", isRunning);
		torsoAnimator.SetBool("inAir",inAir );
		torsoAnimator.SetBool("isRunning", isRunning);
		//print (Input.GetButtonDown ("fire 1"));

		torsoAnimator.SetBool ("isReloading", Input.GetKeyDown (KeyCode.R));
		torsoAnimator.SetBool ("isFiring", checkIsFiring (torsoAnimator.GetBool("isReloading")));

		bobSprite ();
	}


	private void bobSprite() {
		AnimatorStateInfo anim = legAnimator.GetCurrentAnimatorStateInfo(0);
		if (anim.IsName ("Walk_Legs")) {
			float x = torsoOrigin.x;
			float y = torsoOrigin.y;
			float time = anim.normalizedTime;
			y -= 0.01f;
			if (checkBob (time)) {
				y -= .01f;
			}
			Vector2 vec = new Vector2 (x, y);

			torso.localPosition = vec;


		} else {
			torso.localPosition = torsoOrigin;
		}

	}
			        
	bool checkBob(float time) {
		int temp = (int)time;
		time -= temp;
		print (time);
		return (time > 1f/11 && time < 2f/11) || (time > 5f/11 && time < 7f/11);
	}

	private bool checkIsFiring(bool isReloading) {
		return !isReloading && Input.GetKeyDown (KeyCode.F);
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


