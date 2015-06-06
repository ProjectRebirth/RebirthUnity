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


	//The variables below are for the bobbing animation
	public Transform torso;
	private GraysonMechanics grayson;
	private Vector2 torsoOrigin;//The origin of the torsoLocation relative to Grayson
	

	void Start() {
		torsoOrigin = new Vector2 (torso.localPosition.x, torso.localPosition.y);
		grayson = GetComponent<GraysonMechanics> ();
	}

	/**
	 * Updates all animation parameters for the Animator
	 * This currently checks if Grayson is moving
	 * Or if he is falling. All logic for animations should
	 * go here.
	 */ 
	void Update() {
		//GraysonMechanics grayson = GetComponent<GraysonMechanics> ();

		torsoAnimator.SetBool ("isRunning", grayson.getIsRunning ());
		torsoAnimator.SetBool ("inAir", grayson.getInAir ());
	//	print (grayson.getCanFire ());
		torsoAnimator.SetBool ("canFire", grayson.getCanFire());
		torsoAnimator.SetBool("canReload", grayson.getCanReload());
		torsoAnimator.SetBool ("isLookingUp", grayson.getIsLookingUp ());
		torsoAnimator.SetBool ("canStrafe", grayson.getCanStrafe ());
		torsoAnimator.SetBool ("isClimbing", grayson.getIsClimbing ());

		legAnimator.SetBool ("isRunning", grayson.getIsRunning ());
		legAnimator.SetBool ("inAir", grayson.getInAir ());
		legAnimator.SetBool ("isClimbing", grayson.getIsClimbing ());

		bobSprite ();
	}

    /**
     * Helper method to move Grayson's body up and down according to the offset of his current animation
     * At the moment the only animation that requires this is the walk animation.
     */ 
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

	/**
	 * This method moanipulates the image to bob up and down. Currently this is only used if the
	 * sprite is waling. May be needed for other animations that may come in the future;
	 */ 
	bool checkBob(float time) {
		int temp = (int)time;
		time -= temp;
		//print (time);
		return (time > 1f/11 && time < 2f/11) || (time > 5f/11 && time < 7f/11);
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


