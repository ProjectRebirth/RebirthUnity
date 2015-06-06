using UnityEngine;
using System.Collections;


/*
 * This script is used for all of Grayson's mechanics
 * 
 */ 
public class GraysonMechanics : SpriteMechanics {
	public float speed;//The speed that Grayson will be moving from side to side
	public float jumpSpeed;//The height of that Grayson will jump
	public float strafeSideSpeed;
	public float strafeUpSpeed;
	public float climbSpeed;
	public float stamina;
	public Transform torso;
	public Transform legs;
	public Weapon currentWeapon;

	private bool madeJump;
	private bool canStrafe;
	private bool isStrafing;
	private bool inAir;
	private bool isRunning;
	private bool canFire;
	private bool canReload;
	private bool isReloading;
	private bool isFiring;
	private bool isLookingUp;
	private int canClimb;
	private bool isClimbing;

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
		if (!madeJump && !Input.GetKey(KeyCode.F)) {
			if (isRight && horizontalInput < 0) {
				isRight = false;
				transform.localScale = new Vector2 (-1, 1);
			}
			if (!isRight && horizontalInput > 0) {
				transform.localScale = new Vector2 (1, 1);
				isRight = true;
			}
		}
		
	}

	void gravityLogic() {
		Rigidbody2D rigid = GetComponent<Rigidbody2D> ();
		if (isClimbing) {
			rigid.gravityScale = 0;
		} else {
			rigid.gravityScale = 1;
		}
	}


	void Update() {
		strafeLogic ();
		inAir = checkInAir ();
		isRunning = checkISRunning ();
		isStrafing = checkIsStrafing ();

		isFiring = checkIsFiring();
		isReloading = checkIsReloading ();

		//print ("Can Reload: " + canReload);
	}

	void FixedUpdate() {
		gravityLogic ();
	}

	private void climbLogic(float verticalInput) {
		Rigidbody2D rigid = GetComponent<Rigidbody2D> ();
		Vector2 vec = rigid.velocity;
		vec.y = 0;

		if (verticalInput > 0.001f) {
			vec.y = climbSpeed;
		} else if (verticalInput < -0.001f) {
			vec.y = -climbSpeed;
		}
		rigid.velocity = vec;
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

	private bool checkCanClimb() {
		return canClimb > 0 && !isStrafing && !isReloading;
	}

	/**
	 * Takes in vertical direction input from the player.
	 * This is where the logic for looking up and climbing ladders will go
	 */ 
	public void moveVertical(float verticalInput) {
		if (checkCanClimb ()) {
			if (verticalInput > .001f) {
				isClimbing = true;
			}
			if (isClimbing) {
				climbLogic(verticalInput);
			}
		} else {
			if (verticalInput > 0.001f) {
				isLookingUp = true;
			} else {
				isLookingUp = false;
			}
			isClimbing = false;
		}
	}

	/**
	 * Takes in the player's button input and checks to see if a strafe
	 * is possible at this moment
	 */ 
	public void strafe(bool strafeKey) {
		if (checkCanStrafe ()) {
			canStrafe = strafeKey;
		} else
			canStrafe = false;
	}

	/*
	 * Logic for the jump mechanic. If his z velocity is 0 then he can jump
	 */ 
	public void jump(bool jumpKey) {
		Rigidbody2D rigid = GetComponent<Rigidbody2D> ();
		if (!inAir) {
			madeJump = false;
		}
		if (!inAir && jumpKey) {
			Vector2 vec = new Vector2 (rigid.velocity.x, jumpSpeed);
			rigid.velocity = vec;
			madeJump = true;
		}

	}

	/**
	 * Takes in the player's input and if the conditions are met for firing
	 * this will carry out firing logic. If a bullet is fired, this would be 
	 * where to implement this feature
	 */ 
	public void fireWeapon(bool fireButton) {
		if (fireButton) {
			Vector2 dir = getFiringDirection();
			currentWeapon.fireWeapon(dir);
		}
		if (checkCanFire ()) {
			canFire = fireButton;

		} else {
			canFire = false;
		}
	}

	private Vector2 getFiringDirection() {
		if (isLookingUp) {
			return new Vector2(0, 1);
		}
		if (isRight) {
			return new Vector2(1, 0);
		}
		return new Vector2(-1, 0);
	}
	

	public bool checkCanStrafe() {
		return !isStrafing && !isClimbing;
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

		return (Mathf.Abs (rigid.velocity.y) > 0.0001f && madeJump) || Mathf.Abs (rigid.velocity.y) > .5; 
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

	public void strafeLogic() {
		Rigidbody2D rigid = GetComponent<Rigidbody2D> ();
		Vector2 vec = rigid.velocity;
		if (canStrafe) {
			vec.y = strafeUpSpeed;
			if (strafeSideSpeed > 0 && !isRight) strafeSideSpeed *= -1;
			else if(strafeSideSpeed < 0 && isRight) strafeSideSpeed *= -1;

		}
		if (isStrafing) {
			vec.x = strafeSideSpeed;
		}

		rigid.velocity = vec;
	}

	/**
	 * Verifies that a player is allowed to reload his weapon when the reload input is down
	 */ 
	private bool checkCanReload() {
		return !isReloading && !isStrafing && !isClimbing && !currentWeapon.getWeaponIsFull();
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
		return !isReloading && !isFiring && !isStrafing && !isClimbing && !currentWeapon.isEmpty();
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

	public bool getIsReloading() {
		return isReloading;
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

	//Returns whether the player is current clmbing
	public bool getIsClimbing() {
		return isClimbing;
	}

	/**
	 * Built in Unity mnChecks if a collider has interacted with a trigger.
	 * 
	 * To carry out this method I have given all  Climable objects a tag named "Climable"
	 */ 
	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == "Climbable") {
			canClimb += 1;
		}
	}

	/**
	 * Built in Unity function. Checks when a collider has exited a trigger object
	 * 
	 * 
	 */ 
	void OnTriggerExit2D(Collider2D collider) {
		if (collider.tag == "Climbable") {
			canClimb -=1 ; 
		}
	}


}
