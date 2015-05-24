using UnityEngine;
using System.Collections;


/*
 * This script is used for all of Grayson's mechanics
 * 
 */ 
public class GraysonMechanics : MonoBehaviour {
	public float speed;//The speed that Grayson will be moving from side to side
	public float jumpSpeed;//The height of that Grayson will jump
	public float strafeSpeed;
	public Transform torso;
	public Transform legs;


	private bool canStrafe;
	private bool isStrafing;
	private bool inAir;
	private bool isRunning;
	private bool canFire;
	private bool canReload;
	private bool isReloading;
	private bool isFiring;
	private bool isLookingUp;
	public bool isRight;//The direction of the character sprite
	
	
	
	void Start() {
		if (!isRight) {
			this.transform.localScale = new Vector2 (-1, 1);
		}
	}
	/**
	 * Method that helps to see if the character should flip
	 * orientation horizontally
	 */ 
	private void checkFlipTexture(float horizontalInput) {

		if (isRight && horizontalInput < 0) {
			isRight = false;
			transform.localScale = new Vector2 (-1, 1);
		}
		if (!isRight && horizontalInput > 0) {
			transform.localScale = new Vector2 (1, 1);
			isRight = true;
		}
		
	}


	void Update() {
		inAir = checkInAir ();
		isRunning = checkISRunning ();
		isStrafing = checkIsStrafing ();

		isFiring = checkIsFiring();
		isReloading = checkIsReloading ();

		//print ("Can Reload: " + canReload);
	}

	void FixedUpdate() {
		if (isStrafing) {
			Rigidbody2D rigid = GetComponent<Rigidbody2D>();
			Vector2 vec = rigid.velocity;
			vec.x = strafeSpeed;
		}
	}


	/*
	 * Logic for moving forward based on inputs from the player
	 */ 
	public void moveHorizontal(float horizontalInput) {
		checkFlipTexture (horizontalInput);

		Rigidbody2D rigid = GetComponent<Rigidbody2D>();
		Vector2 vec = new Vector2 (speed * horizontalInput, rigid.velocity.y);
		rigid.velocity = vec;
	}

	/**
	 * Takes in vertical direction input from the player.
	 * This is where the logic for looking up and climbing ladders will go
	 */ 
	public void moveVertical(float verticalInput) {
		if (verticalInput > 0.001f) {
			isLookingUp = true;
		} else {
			isLookingUp = false;
		}
	}

	/**
	 * Takes in the player's button input and checks to see if a strafe
	 * is possible at this moment
	 */ 
	public void strafe(bool strafeKey) {

	}

	/*
	 * Logic for the jump mechanic. If his z velocity is 0 then he can jump
	 */ 
	public void jump(bool jumpKey) {
		Rigidbody2D rigid = GetComponent<Rigidbody2D> ();

		if (Mathf.Abs(rigid.velocity.y) == 0 && jumpKey) {
			Vector2 vec = new Vector2 (rigid.velocity.x, jumpSpeed);
			rigid.velocity = vec;
		}
	}

	/**
	 * Takes in the player's input and if the conditions are met for firing
	 * this will carry out firing logic. If a bullet is fired, this would be 
	 * where to implement this feature
	 */ 
	public void fireWeapon(bool fireButton) {
		if (checkCanFire ()) {
			canFire = fireButton;
		} else {
			canFire = false;
		}
	}

	/**
	 * Takes in the player's input for reloading their weapon. If the conditions
	 * are met for reloading, then the logic and animation will carry out
	 */ 
	public void reloadWeapon(bool reloadButton) {
		if (checkCanReload ()) {
			canReload = reloadButton;

			//print (reloadButton);
		} else {
			canReload = false;
		}
	}

	/**
	 * If the player is moving vertically then the player is considered in the air.
	 * May not be the best implementation, but its worked so far, so.... yeah...
	 */
	private bool checkInAir() {
		Rigidbody2D rigid = GetComponent<Rigidbody2D> ();

		return Mathf.Abs (rigid.velocity.y) > 0f; 
	}

	/**
	 * If the player is moving horizontally, then they are considered to be
	 * running according to this logic. Could use a better implementation,
	 * but for what is needed it seems to be working fine
	 */ 
	private bool checkISRunning() {
		Rigidbody2D rigid = GetComponent<Rigidbody2D> ();
		float x = rigid.velocity.x;
		return Mathf.Abs (x) > 0f;
	}

	/**
	 * Verifies that a player is allowed to reload his weapon when the reload input is down
	 */ 
	private bool checkCanReload() {
		return !isReloading && !isStrafing;
	}


	/**
	 * If the strafing animation is still playing out, then the player is 
	 * considered to be strafing (if strafing animation playing, then isStrafing = true)
	 */ 
	private bool checkIsStrafing() {
		Animator torsoAnimator = torso.GetComponent<Animator> ();
		AnimatorStateInfo currentState = torsoAnimator.GetCurrentAnimatorStateInfo (0);
		if (currentState.IsName ("Strafe_Torso")) {
			return true;
		}
		return false;
	}

	/**
	 * Checks to see that the player can fire his weapon based on whether the player is currently reloading his
	 * weapon, currently firing, and whether he is strafing
	 */ 
	private bool checkCanFire() {
		return !isReloading && !isFiring && !isStrafing;
	}

	/**
	 * If the animation for reloading is currently playing, then the character is considered to
	 * be reloading
	 */ 
	private bool checkIsReloading() {
		Animator torsoAnimator = torso.GetComponent<Animator> ();
		AnimatorStateInfo currentClip = torsoAnimator.GetCurrentAnimatorStateInfo (0);
		if (currentClip.IsName("Reload_Torso")) {
			return true;
		}
		return false;
	}

	/**
	 * If the animation for the shooting is currently playing then the player is considered to be firing
	 */ 
	private bool checkIsFiring() {
		Animator torsoAnimator = torso.GetComponent<Animator> ();
		AnimatorStateInfo currentState = torsoAnimator.GetCurrentAnimatorStateInfo (0);
		if (currentState.IsName ("Fire_Torso") || currentState.IsName("Fire_Torso_Up")) {
			return true;
		}
		return false;
	}

	//Returns the variable that contains information about whether the player is looking up
	public bool getIsLookingUp() {
		return isLookingUp;
	}

	//This variable will be true for one instance before the firing animation takes place
	//Use this to carryout any logic needed before hand
	public bool getCanReload() {
		return canReload;
	}

	//This variable will be true one frame before the firing animation takes place.
	//Use this to carry out any task needed before firing the weapon
	public bool getCanFire() {
		return canFire;
	}

	//Variable that lets you know that the player is moving horizontally.
	//......Maybe the name should be changed in a future update.
	public bool getIsRunning() {
		return isRunning;
	}

	//Variable that lets you know that the player is moving vertically
	//....The name for this seems fine, but I can see it being a problem with ropes
	//and shit
	public bool getInAir() {
		return inAir;
	}

	//This variable will be true one frame before the strafe animation carries out.
	//Use it where needed.
	public bool getCanStrafe() {
		return canStrafe;
	}

	//Variable that lets the program know that the character is strafing
	public bool getIsStrafing() {
		return isStrafing;
	}
}
